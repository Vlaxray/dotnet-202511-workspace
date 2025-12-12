// src/components/OptimizedThreeDScene.jsx
import React, { useRef, useEffect, useState } from 'react';
import { Canvas, useFrame } from '@react-three/fiber';
import { usePerformance } from './PerformanceWrapper';
import { useParticleOptimization } from '../utils/performance';

function OptimizedParticles({ count = 1000 }) {
    const particlesRef = useRef();
    const { addFrameCallback, removeFrameCallback } = usePerformance();
    
    // Ottimizza le particelle con useParticleOptimization
    const particleData = useParticleOptimization(count);
    
    useEffect(() => {
        if (!particleData) return;
        
        const updateParticles = (time) => {
            if (particlesRef.current) {
                const positions = particlesRef.current.geometry.attributes.position.array;
                
                for (let i = 0; i < count; i++) {
                    const i3 = i * 3;
                    positions[i3 + 1] += Math.sin(time * 0.001 + i) * 0.005;
                }
                
                particlesRef.current.geometry.attributes.position.needsUpdate = true;
            }
        };
        
        addFrameCallback(updateParticles);
        
        return () => {
            removeFrameCallback(updateParticles);
        };
    }, [count, particleData, addFrameCallback, removeFrameCallback]);

    if (!particleData) return null;

    return (
        <points ref={particlesRef}>
            <bufferGeometry>
                <bufferAttribute
                    attach="attributes-position"
                    count={count}
                    array={particleData.positions}
                    itemSize={3}
                />
                <bufferAttribute
                    attach="attributes-color"
                    count={count}
                    array={particleData.colors}
                    itemSize={3}
                />
            </bufferGeometry>
            <pointsMaterial
                size={0.05}
                vertexColors
                transparent
                opacity={0.8}
            />
        </points>
    );
}

export default function OptimizedThreeDScene() {
    const [isMobile, setIsMobile] = useState(false);
    
    useEffect(() => {
        // Rileva se è mobile per ottimizzazioni specifiche
        const checkMobile = () => {
            setIsMobile(window.innerWidth <= 768);
        };
        
        checkMobile();
        window.addEventListener('resize', checkMobile);
        
        return () => {
            window.removeEventListener('resize', checkMobile);
        };
    }, []);

    return (
        <div className={`cyber-3d-element ${isMobile ? 'mobile-optimized' : ''}`}>
            <Canvas
                camera={{ position: [0, 0, 5], fov: isMobile ? 60 : 75 }}
                dpr={isMobile ? 1 : 2} // Riduci pixel ratio su mobile
                performance={{ min: 0.5 }} // Riduci FPS su dispositivi lenti
            >
                <ambientLight intensity={isMobile ? 0.3 : 0.5} />
                <OptimizedParticles count={isMobile ? 500 : 2000} />
                {/* Altri componenti ottimizzati */}
            </Canvas>
        </div>
    );
}