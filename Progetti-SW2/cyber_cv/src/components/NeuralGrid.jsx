// src/components/NeuralGrid.jsx
import React, { useRef, useMemo } from 'react';
import { Canvas, useFrame } from '@react-three/fiber';
import * as THREE from 'three';

function NeuralConnection({ start, end }) {
    const ref = useRef();
    
    const curve = useMemo(() => {
        const points = [];
        const segments = 20;
        
        for (let i = 0; i <= segments; i++) {
            const t = i / segments;
            const x = start.x + (end.x - start.x) * t;
            const y = start.y + (end.y - start.y) * t;
            const z = start.z + (end.z - start.z) * t + Math.sin(t * Math.PI) * 0.5;
            
            points.push(new THREE.Vector3(x, y, z));
        }
        
        return new THREE.CatmullRomCurve3(points);
    }, [start, end]);

    useFrame((state) => {
        if (ref.current) {
            ref.current.material.uniforms.time.value = state.clock.elapsedTime;
        }
    });

    return (
        <mesh>
            <tubeGeometry args={[curve, 64, 0.02, 8, false]} />
            <shaderMaterial
                transparent
                uniforms={{
                    time: { value: 0 },
                    color: { value: new THREE.Color('#00eeff') }
                }}
                vertexShader={`
                    uniform float time;
                    varying float vAlpha;
                    
                    void main() {
                        vec3 pos = position;
                        pos.x += sin(pos.y * 5.0 + time * 2.0) * 0.1;
                        pos.y += cos(pos.x * 5.0 + time * 2.0) * 0.1;
                        
                        gl_Position = projectionMatrix * modelViewMatrix * vec4(pos, 1.0);
                        vAlpha = sin(uv.x * 3.14159) * 0.5 + 0.5;
                    }
                `}
                fragmentShader={`
                    uniform vec3 color;
                    varying float vAlpha;
                    
                    void main() {
                        gl_FragColor = vec4(color, vAlpha * 0.3);
                    }
                `}
            />
        </mesh>
    );
}

function NeuralNode({ position, size = 0.1 }) {
    const ref = useRef();
    
    useFrame((state) => {
        if (ref.current) {
            ref.current.scale.x = Math.sin(state.clock.elapsedTime * 2) * 0.2 + 1;
            ref.current.scale.y = Math.cos(state.clock.elapsedTime * 2) * 0.2 + 1;
        }
    });

    return (
        <mesh ref={ref} position={position}>
            <sphereGeometry args={[size, 16, 16]} />
            <meshBasicMaterial
                color="#00eeff"
                transparent
                opacity={0.8}
                blending={THREE.AdditiveBlending}
            />
        </mesh>
    );
}

function NeuralNetwork({ count = 20 }) {
    const nodes = useMemo(() => {
        return Array.from({ length: count }, () => ({
            position: new THREE.Vector3(
                (Math.random() - 0.5) * 10,
                (Math.random() - 0.5) * 10,
                (Math.random() - 0.5) * 5
            )
        }));
    }, [count]);

    const connections = useMemo(() => {
        const conns = [];
        for (let i = 0; i < nodes.length; i++) {
            for (let j = i + 1; j < nodes.length; j++) {
                if (Math.random() > 0.7) {
                    conns.push({
                        start: nodes[i].position,
                        end: nodes[j].position
                    });
                }
            }
        }
        return conns;
    }, [nodes]);

    return (
        <group>
            {nodes.map((node, index) => (
                <NeuralNode key={index} position={node.position} />
            ))}
            {connections.map((conn, index) => (
                <NeuralConnection key={index} start={conn.start} end={conn.end} />
            ))}
        </group>
    );
}

export default function NeuralGrid() {
    return (
        <div style={{
            position: 'fixed',
            top: 0,
            left: 0,
            width: '100%',
            height: '100%',
            zIndex: 0,
            pointerEvents: 'none'
        }}>
            <Canvas camera={{ position: [0, 0, 15], fov: 60 }}>
                <ambientLight intensity={0.2} />
                <pointLight position={[10, 10, 10]} intensity={1} color="#00eeff" />
                
                <NeuralNetwork count={15} />
                
                <mesh rotation={[-Math.PI / 2, 0, 0]} position={[0, -5, 0]}>
                    <planeGeometry args={[20, 20]} />
                    <meshBasicMaterial
                        color="#001122"
                        transparent
                        opacity={0.1}
                        side={THREE.DoubleSide}
                    />
                </mesh>
            </Canvas>
        </div>
    );
}