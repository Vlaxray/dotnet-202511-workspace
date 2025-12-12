// src/components/PerformanceWrapper.jsx
import React, { useMemo, useState, useEffect, useRef } from 'react';
import { 
    usePerformanceOptimization, 
    useThreePerformance,
    useWebGLOptimization,
    useMobileOptimization
} from '../utils/performance';

// Context per le ottimizzazioni
export const PerformanceContext = React.createContext({
    addFrameCallback: () => {},
    removeFrameCallback: () => {},
    isMobile: false,
    isLowPower: false
});

// Hook per usare le ottimizzazioni nei componenti figli
export const usePerformance = () => React.useContext(PerformanceContext);

// Componente wrapper principale
export const PerformanceWrapper = ({ children, enable3D = true }) => {
    // Attiva tutte le ottimizzazioni
    usePerformanceOptimization(enable3D);
    useWebGLOptimization();
    
    // Ottimizzazioni specifiche Three.js
    const threePerf = useThreePerformance();
    
    // Ottimizzazioni per mobile
    const mobileOpts = useMobileOptimization();
    
    // Espone le funzioni di ottimizzazione Three.js ai figli
    const contextValue = useMemo(() => ({
        addFrameCallback: threePerf.addFrameCallback,
        removeFrameCallback: threePerf.removeFrameCallback,
        isMobile: mobileOpts.isMobile,
        isLowPower: mobileOpts.isLowPower,
        optimizeForMobile: mobileOpts.optimizeForMobile,
        particleCount: mobileOpts.particleCount,
        animationQuality: mobileOpts.animationQuality
    }), [threePerf, mobileOpts]);

    return (
        <PerformanceContext.Provider value={contextValue}>
            {children}
        </PerformanceContext.Provider>
    );
};

// Componente HOC per ottimizzare componenti
export const withPerformance = (Component) => {
    const WrappedComponent = React.forwardRef((props, ref) => (
        <PerformanceWrapper>
            <Component ref={ref} {...props} />
        </PerformanceWrapper>
    ));
    
    WrappedComponent.displayName = `withPerformance(${Component.displayName || Component.name})`;
    return WrappedComponent;
};

// Componente per debouncing degli eventi
export const DebouncedComponent = ({ children, delay = 100, placeholder = null, ...props }) => {
    const [isReady, setIsReady] = useState(false);
    const timerRef = useRef(null);

    useEffect(() => {
        timerRef.current = setTimeout(() => {
            setIsReady(true);
        }, delay);

        return () => {
            if (timerRef.current) {
                clearTimeout(timerRef.current);
            }
        };
    }, [delay]);

    if (!isReady) {
        return placeholder || (
            <div className="debounced-placeholder" style={{
                opacity: 0.5,
                filter: 'blur(2px)',
                transition: 'all 0.3s ease'
            }}>
                {/* Placeholder mentre carica */}
            </div>
        );
    }

    return React.cloneElement(children, props);
};

// Componente per lazy loading con intersezione observer
export const LazyLoadComponent = ({ 
    children, 
    threshold = 0.1, 
    rootMargin = '50px',
    placeholder = null,
    style = {}
}) => {
    const [isVisible, setIsVisible] = useState(false);
    const ref = useRef(null);

    useEffect(() => {
        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    setIsVisible(true);
                    observer.unobserve(entry.target);
                }
            },
            { threshold, rootMargin }
        );

        const currentRef = ref.current;
        if (currentRef) {
            observer.observe(currentRef);
        }

        return () => {
            if (currentRef) {
                observer.unobserve(currentRef);
            }
        };
    }, [threshold, rootMargin]);

    return (
        <div 
            ref={ref} 
            style={{ minHeight: '1px', ...style }}
            className="lazy-load-container"
        >
            {isVisible ? children : (
                placeholder || (
                    <div className="lazy-placeholder" style={{
                        height: '100px',
                        background: 'rgba(0, 30, 60, 0.3)',
                        borderRadius: '5px',
                        border: '1px dashed rgba(0, 238, 255, 0.2)',
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        color: 'rgba(0, 238, 255, 0.5)',
                        fontFamily: 'monospace',
                        fontSize: '0.8rem'
                    }}>
                        <span className="blink">█</span> CARICAMENTO MODULO...
                    </div>
                )
            )}
        </div>
    );
};

// Componente per performance monitoring
export const PerformanceMonitor = ({ componentName, logMount = true, logRender = false }) => {
    const mountTime = useRef(performance.now());
    const renderCount = useRef(0);

    useEffect(() => {
        if (logMount) {
            const mountDuration = performance.now() - mountTime.current;
            console.log(`[Perf] ${componentName} montato in: ${mountDuration.toFixed(2)}ms`);
        }
        
        return () => {
            if (logMount) {
                console.log(`[Perf] ${componentName} smontato. Render totali: ${renderCount.current}`);
            }
        };
    }, [componentName, logMount]);

    useEffect(() => {
        renderCount.current++;
        if (logRender && renderCount.current > 1) {
            console.log(`[Perf] ${componentName} render #${renderCount.current}`);
        }
    });

    return null;
};

// Componente per virtual scrolling ottimizzato
export const VirtualScroll = ({
    items,
    itemHeight,
    renderItem,
    overscan = 5,
    style = {},
    className = ''
}) => {
    const containerRef = useRef(null);
    const [scrollTop, setScrollTop] = useState(0);
    const [height, setHeight] = useState(0);

    useEffect(() => {
        const container = containerRef.current;
        if (!container) return;

        const updateHeight = () => {
            setHeight(container.clientHeight);
        };

        const handleScroll = () => {
            setScrollTop(container.scrollTop);
        };

        updateHeight();
        window.addEventListener('resize', updateHeight);
        container.addEventListener('scroll', handleScroll, { passive: true });

        return () => {
            window.removeEventListener('resize', updateHeight);
            container.removeEventListener('scroll', handleScroll);
        };
    }, []);

    const totalHeight = items.length * itemHeight;
    const startIndex = Math.max(0, Math.floor(scrollTop / itemHeight) - overscan);
    const endIndex = Math.min(
        items.length,
        Math.ceil((scrollTop + height) / itemHeight) + overscan
    );

    const visibleItems = items.slice(startIndex, endIndex);
    const offsetTop = startIndex * itemHeight;

    return (
        <div
            ref={containerRef}
            style={{ 
                overflowY: 'auto', 
                position: 'relative',
                ...style 
            }}
            className={`virtual-scroll-container ${className}`}
        >
            <div style={{ height: totalHeight }}>
                <div style={{ 
                    position: 'absolute', 
                    top: offsetTop, 
                    width: '100%' 
                }}>
                    {visibleItems.map((item, index) => (
                        <div 
                            key={startIndex + index}
                            style={{ height: itemHeight }}
                        >
                            {renderItem(item, startIndex + index)}
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

// Componente per progressive image loading
export const ProgressiveImage = ({
    src,
    placeholderSrc,
    alt = '',
    style = {},
    className = '',
    onLoad,
    onError
}) => {
    const [isLoaded, setIsLoaded] = useState(false);
    const [currentSrc, setCurrentSrc] = useState(placeholderSrc || src);

    useEffect(() => {
        const img = new Image();
        
        img.src = src;
        img.onload = () => {
            setCurrentSrc(src);
            setIsLoaded(true);
            if (onLoad) onLoad();
        };
        
        img.onerror = (error) => {
            if (onError) onError(error);
        };

        return () => {
            img.onload = null;
            img.onerror = null;
        };
    }, [src, onLoad, onError]);

    return (
        <img
            src={currentSrc}
            alt={alt}
            style={{
                opacity: isLoaded ? 1 : 0.5,
                filter: isLoaded ? 'none' : 'blur(5px)',
                transition: 'opacity 0.3s ease, filter 0.3s ease',
                ...style
            }}
            className={`progressive-image ${isLoaded ? 'loaded' : 'loading'} ${className}`}
            loading="lazy"
        />
    );
};

// Componente per gestire WebGL context
export const WebGLOptimizer = ({ children, antialias = true, alpha = false }) => {
    const canvasRef = useRef(null);

    useEffect(() => {
        if (!canvasRef.current) return;

        const canvas = canvasRef.current;
        const contextOptions = {
            antialias,
            alpha,
            powerPreference: 'high-performance',
            preserveDrawingBuffer: false
        };

        // Crea il contesto WebGL con ottimizzazioni
        const gl = canvas.getContext('webgl2', contextOptions) || 
                  canvas.getContext('webgl', contextOptions);

        if (gl) {
            // Applica ottimizzazioni
            gl.disable(gl.DEPTH_TEST);
            gl.enable(gl.CULL_FACE);
            gl.cullFace(gl.BACK);
            
            // Estensioni ottimizzate
            gl.getExtension('EXT_color_buffer_float');
            gl.getExtension('OES_texture_float_linear');
        }

        return () => {
            // Cleanup
            if (gl) {
                gl.getExtension('WEBGL_lose_context')?.loseContext();
            }
        };
    }, [antialias, alpha]);

    return React.cloneElement(children, { ref: canvasRef });
};

// Esporta tutto in un oggetto
const PerformanceUtils = {
    PerformanceWrapper,
    withPerformance,
    DebouncedComponent,
    LazyLoadComponent,
    PerformanceMonitor,
    VirtualScroll,
    ProgressiveImage,
    WebGLOptimizer,
    usePerformance
};

export default PerformanceUtils;

