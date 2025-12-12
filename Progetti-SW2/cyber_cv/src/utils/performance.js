// src/utils/performance.js
import React, { useState, useEffect, useMemo, useCallback, useRef } from 'react';

/**
 * Hook per ottimizzare le performance delle animazioni 3D
 * Attiva hardware acceleration e gestisce event listeners
 */
export const usePerformanceOptimization = (enable3DAcceleration = true) => {
    useEffect(() => {
        if (!enable3DAcceleration) return;

        const optimizations = [];

        // 1. Attiva hardware acceleration per animazioni
        const accelerationStyle = document.createElement('style');
        accelerationStyle.textContent = `
            .cyber-3d-element {
                transform: translate3d(0,0,0);
                backface-visibility: hidden;
                perspective: 1000px;
                will-change: transform, opacity;
            }
            
            .cyber-particle {
                transform: translateZ(0);
                backface-visibility: hidden;
            }
        `;
        document.head.appendChild(accelerationStyle);
        optimizations.push(() => document.head.removeChild(accelerationStyle));

        // 2. Gestione efficiente degli event listeners per scroll
        let ticking = false;
        const handleScroll = () => {
            if (!ticking) {
                requestAnimationFrame(() => {
                    // Qui potresti aggiornare animazioni basate sullo scroll
                    ticking = false;
                });
                ticking = true;
            }
        };

        // Usa passive event listener per migliorare lo scroll performance
        window.addEventListener('scroll', handleScroll, { passive: true });
        optimizations.push(() => window.removeEventListener('scroll', handleScroll));

        // 3. Riduci il framerate su dispositivi mobile
        const reduceFramerate = () => {
            const isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
            if (isMobile) {
                const style = document.createElement('style');
                style.textContent = `
                    @media (max-width: 768px) {
                        .cyber-particle {
                            animation-duration: 1.5s !important;
                        }
                        .floating-element {
                            animation-duration: 4s !important;
                        }
                    }
                `;
                document.head.appendChild(style);
                optimizations.push(() => document.head.removeChild(style));
            }
        };
        reduceFramerate();

        return () => {
            optimizations.forEach(cleanup => cleanup());
        };
    }, [enable3DAcceleration]);
};

/**
 * Memoizza componenti pesanti con dipendenze profonde
 */
export const useMemoizedComponent = (Component, dependencies = []) => {
    return useMemo(() => Component, dependencies);
};

/**
 * Componente wrapper per lazy loading con fallback ottimizzato
 */
export const lazyLoadComponent = (importFunc, fallback = null) => {
    const LazyComponent = React.lazy(importFunc);
    
    return React.forwardRef((props, ref) => (
        <React.Suspense 
            fallback={fallback || (
                <div className="cyber-loading" style={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    minHeight: '200px',
                    color: '#00eeff'
                }}>
                    <div className="loading-pulse">▒▒▒▒▒▒▒▒▒▒▒</div>
                </div>
            )}
        >
            <LazyComponent ref={ref} {...props} />
        </React.Suspense>
    ));
};

/**
 * Hook per gestire efficientemente animazioni Three.js
 */
export const useThreePerformance = () => {
    const frameCallbacks = useRef([]);
    const animationFrameId = useRef(null);

    const addFrameCallback = useCallback((callback) => {
        frameCallbacks.current.push(callback);
    }, []);

    const removeFrameCallback = useCallback((callback) => {
        frameCallbacks.current = frameCallbacks.current.filter(cb => cb !== callback);
    }, []);

    useEffect(() => {
        const animate = (time) => {
            frameCallbacks.current.forEach(callback => callback(time));
            animationFrameId.current = requestAnimationFrame(animate);
        };
        
        animationFrameId.current = requestAnimationFrame(animate);
        
        return () => {
            if (animationFrameId.current) {
                cancelAnimationFrame(animationFrameId.current);
            }
        };
    }, []);

    return { addFrameCallback, removeFrameCallback };
};

/**
 * Debounce per eventi frequenti (scroll, resize, etc.)
 */
export const useDebouncedCallback = (callback, delay) => {
    const timeoutRef = useRef();

    return useCallback((...args) => {
        if (timeoutRef.current) {
            clearTimeout(timeoutRef.current);
        }
        
        timeoutRef.current = setTimeout(() => {
            callback(...args);
        }, delay);
    }, [callback, delay]);
};

/**
 * Hook per caricamento progressivo delle risorse 3D
 */
export const useProgressiveLoading = (resources, onProgress) => {
    const [loaded, setLoaded] = useState(false);
    const [progress, setProgress] = useState(0);

    useEffect(() => {
        let completed = 0;
        const total = resources.length;

        const handleResourceLoad = () => {
            completed++;
            const newProgress = Math.round((completed / total) * 100);
            setProgress(newProgress);
            
            if (onProgress) {
                onProgress(newProgress);
            }
            
            if (completed === total) {
                setLoaded(true);
            }
        };

        resources.forEach(resource => {
            if (resource instanceof HTMLImageElement) {
                resource.onload = handleResourceLoad;
                resource.onerror = handleResourceLoad; // Gestisci anche gli errori
            }
            // Aggiungi altri tipi di risorse se necessario (modelli 3D, etc.)
        });
    }, [resources, onProgress]);

    return { loaded, progress };
};

/**
 * Ottimizzazione memoria per particelle Three.js
 */
export const useParticleOptimization = (particleCount, enabled = true) => {
    const particleData = useMemo(() => {
        if (!enabled) return null;

        const positions = new Float32Array(particleCount * 3);
        const colors = new Float32Array(particleCount * 3);
        
        for (let i = 0; i < particleCount; i++) {
            const i3 = i * 3;
            positions[i3] = (Math.random() - 0.5) * 10;
            positions[i3 + 1] = (Math.random() - 0.5) * 10;
            positions[i3 + 2] = (Math.random() - 0.5) * 10;
            
            colors[i3] = Math.random();
            colors[i3 + 1] = Math.random();
            colors[i3 + 2] = Math.random();
        }
        
        return { positions, colors };
    }, [particleCount, enabled]);

    return particleData;
};

/**
 * Preload immagini critiche per migliorare UX
 */
export const preloadCriticalImages = (imageUrls) => {
    imageUrls.forEach(url => {
        const img = new Image();
        img.src = url;
    });
};

/**
 * Gestione efficiente dei WebGL contexts
 */
export const useWebGLOptimization = () => {
    useEffect(() => {
        // Salva lo stato WebGL originale per ripristinarlo dopo
        const originalGetContext = HTMLCanvasElement.prototype.getContext;
        
        HTMLCanvasElement.prototype.getContext = function(...args) {
            const contextType = args[0];
            
            if (contextType === 'webgl' || contextType === 'webgl2') {
                const context = originalGetContext.apply(this, args);
                
                if (context) {
                    // Ottimizzazioni WebGL
                    context.disable(context.DEPTH_TEST);
                    context.enable(context.CULL_FACE);
                    context.cullFace(context.BACK);
                    
                    // Configura antialiasing
                    context.getExtension('OES_standard_derivatives');
                    context.getExtension('EXT_shader_texture_lod');
                    context.getExtension('OES_texture_float_linear');
                }
                
                return context;
            }
            
            return originalGetContext.apply(this, args);
        };
        
        return () => {
            HTMLCanvasElement.prototype.getContext = originalGetContext;
        };
    }, []);
};

/**
 * Hook per ottimizzare il rendering di liste grandi
 */
export const useVirtualizedRendering = (items, itemHeight, containerRef) => {
    const [visibleRange, setVisibleRange] = useState({ start: 0, end: 20 });
    const [scrollTop, setScrollTop] = useState(0);

    useEffect(() => {
        const container = containerRef.current;
        if (!container) return;

        const handleScroll = () => {
            const scrollTop = container.scrollTop;
            setScrollTop(scrollTop);
            
            const start = Math.floor(scrollTop / itemHeight);
            const end = Math.min(
                items.length,
                start + Math.ceil(container.clientHeight / itemHeight) + 5
            );
            
            setVisibleRange({ start, end });
        };

        container.addEventListener('scroll', handleScroll, { passive: true });
        handleScroll(); // Inizializza
        
        return () => {
            container.removeEventListener('scroll', handleScroll);
        };
    }, [items.length, itemHeight, containerRef]);

    const visibleItems = items.slice(visibleRange.start, visibleRange.end);
    
    return {
        visibleItems,
        totalHeight: items.length * itemHeight,
        offsetTop: visibleRange.start * itemHeight,
        scrollTop
    };
};

/**
 * Hook per performance monitoring
 */
export const usePerformanceMonitor = (componentName) => {
    const mountTime = useRef(performance.now());
    const renderCount = useRef(0);

    useEffect(() => {
        const mountDuration = performance.now() - mountTime.current;
        console.log(`[Perf] ${componentName} montato in: ${mountDuration.toFixed(2)}ms`);
        
        return () => {
            console.log(`[Perf] ${componentName} smontato. Render totali: ${renderCount.current}`);
        };
    }, [componentName]);

    useEffect(() => {
        renderCount.current++;
    });
};

/**
 * Hook per gestire animazioni efficientemente su mobile
 */
export const useMobileOptimization = () => {
    const [isMobile, setIsMobile] = useState(false);
    const [isLowPower, setIsLowPower] = useState(false);

    useEffect(() => {
        // Rileva se è mobile
        const checkMobile = () => {
            const mobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent) || 
                         window.innerWidth <= 768;
            setIsMobile(mobile);
        };

        // Rileva se è in modalità risparmio energia
        const checkPowerMode = () => {
            if ('hardwareConcurrency' in navigator) {
                const cores = navigator.hardwareConcurrency;
                setIsLowPower(cores <= 4);
            }
        };

        // Rileva se supporta WebGL 2
        const checkWebGLSupport = () => {
            const canvas = document.createElement('canvas');
            const gl = canvas.getContext('webgl2') || canvas.getContext('webgl');
            return !!gl;
        };

        checkMobile();
        checkPowerMode();
        
        window.addEventListener('resize', checkMobile);
        
        return () => {
            window.removeEventListener('resize', checkMobile);
        };
    }, []);

    return {
        isMobile,
        isLowPower,
        optimizeForMobile: isMobile || isLowPower,
        particleCount: isMobile ? 500 : (isLowPower ? 1000 : 2000),
        animationQuality: isMobile ? 'low' : (isLowPower ? 'medium' : 'high')
    };
};

/**
 * Hook per gestire il memory leak prevention
 */
export const useMemoryLeakPrevention = () => {
    const cleanupCallbacks = useRef([]);

    const addCleanupCallback = useCallback((callback) => {
        cleanupCallbacks.current.push(callback);
    }, []);

    useEffect(() => {
        return () => {
            // Esegui tutte le callback di cleanup
            cleanupCallbacks.current.forEach(callback => {
                try {
                    callback();
                } catch (error) {
                    console.warn('Cleanup callback error:', error);
                }
            });
            cleanupCallbacks.current = [];
        };
    }, []);

    return { addCleanupCallback };
};

// Esporta tutto in un oggetto
const PerformanceUtils = {
    usePerformanceOptimization,
    useMemoizedComponent,
    lazyLoadComponent,
    useThreePerformance,
    useDebouncedCallback,
    useProgressiveLoading,
    useParticleOptimization,
    preloadCriticalImages,
    useWebGLOptimization,
    useVirtualizedRendering,
    usePerformanceMonitor,
    useMobileOptimization,
    useMemoryLeakPrevention
};

export default PerformanceUtils;
