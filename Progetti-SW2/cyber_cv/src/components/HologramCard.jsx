// src/components/HologramCard.jsx
import React, { useRef, useState } from 'react';
import { Canvas, useFrame } from '@react-three/fiber';
import { Text, Float, Html, useTexture } from '@react-three/drei';
import * as THREE from 'three';
import { motion } from 'framer-motion';
import { FaCode, FaServer, FaDatabase, FaTerminal, FaDownload } from 'react-icons/fa';

// Componente 3D per la card olografica
function Hologram3D({ isOpen, toggleCard }) {
    const cardRef = useRef();
    const hologramRef = useRef();
    
    useFrame((state) => {
        if (cardRef.current) {
            // Effetto di fluttuazione leggera
            cardRef.current.position.y = Math.sin(state.clock.elapsedTime) * 0.05;
            
            // Rotazione lenta
            if (!isOpen) {
                cardRef.current.rotation.y = Math.sin(state.clock.elapsedTime * 0.3) * 0.1;
            }
        }
        
        if (hologramRef.current) {
            hologramRef.current.rotation.y = state.clock.elapsedTime * 0.5;
        }
    });

    return (
        <group ref={cardRef} position={[0, 0, 0]}>
            {/* Base della card */}
            <mesh onClick={toggleCard} castShadow receiveShadow>
                <boxGeometry args={[3, 4, 0.1]} />
                <meshPhysicalMaterial
                    color="#001122"
                    metalness={0.9}
                    roughness={0.1}
                    clearcoat={1}
                    clearcoatRoughness={0}
                    emissive="#003344"
                    emissiveIntensity={0.2}
                />
            </mesh>
            
            {/* Ologramma centrale */}
            <mesh ref={hologramRef} position={[0, 0, 0.2]}>
                <cylinderGeometry args={[0.8, 0.8, 0.1, 32]} />
                <meshBasicMaterial
                    color="#00eeff"
                    transparent
                    opacity={0.6}
                    side={THREE.DoubleSide}
                />
            </mesh>
            
            {/* Effetti olografici */}
            {isOpen && (
                <>
                    <mesh position={[0, 0, 0.5]}>
                        <sphereGeometry args={[0.3, 16, 16]} />
                        <meshBasicMaterial
                            color="#ff00ff"
                            transparent
                            opacity={0.4}
                            wireframe
                        />
                    </mesh>
                    
                    {/* Linee di connessione */}
                    {[...Array(8)].map((_, i) => (
                        <mesh key={i} position={[0, 0, 0.2]}>
                            <ringGeometry args={[1, 1.1, 32, 1, i * Math.PI/4, Math.PI/16]} />
                            <meshBasicMaterial
                                color="#00ff9d"
                                transparent
                                opacity={0.3}
                                side={THREE.DoubleSide}
                            />
                        </mesh>
                    ))}
                </>
            )}
            
            {/* Testo 3D sulla card */}
            <Text
                position={[0, 1.5, 0.11]}
                fontSize={0.3}
                color="#00eeff"
                anchorX="center"
                anchorY="middle"
            >
                ALEX ROGUE
            </Text>
            
            <Text
                position={[0, 1.2, 0.11]}
                fontSize={0.15}
                color="#00ff9d"
                anchorX="center"
                anchorY="middle"
            >
                FULL-STACK DEVELOPER
            </Text>
        </group>
    );
}

// Componente per il contenuto HTML della card
function CardContent({ isOpen }) {
    const skills = [
        { name: "React/Three.js", level: 95, icon: <FaCode /> },
        { name: "Cybersecurity", level: 88, icon: <FaServer /> },
        { name: "Database Systems", level: 82, icon: <FaDatabase /> },
        { name: "DevOps", level: 78, icon: <FaTerminal /> }
    ];

    return (
        <Html position={[0, -1, 0.5]} center>
            <motion.div
                className="hologram-content"
                initial={{ opacity: 0, scale: 0.8 }}
                animate={{ 
                    opacity: isOpen ? 1 : 0,
                    scale: isOpen ? 1 : 0.8
                }}
                transition={{ duration: 0.3 }}
                style={{
                    width: '400px',
                    background: 'rgba(0, 20, 40, 0.9)',
                    backdropFilter: 'blur(10px)',
                    border: '2px solid #00eeff',
                    borderRadius: '10px',
                    padding: '20px',
                    boxShadow: '0 0 30px rgba(0, 238, 255, 0.5)'
                }}
            >
                <div className="content-header">
                    <h2 style={{ color: '#00eeff', marginBottom: '10px' }}>SISTEMA DI PROFILO</h2>
                    <div className="status-indicator">
                        <span style={{ color: '#00ff9d' }}>█ ONLINE</span>
                        <span style={{ marginLeft: '20px', color: '#888' }}>v2.5.1</span>
                    </div>
                </div>
                
                <div className="skills-section">
                    <h3 style={{ color: '#ff00ff', margin: '20px 0 10px 0' }}>
                        // COMPETENZE PRIMARIE
                    </h3>
                    {skills.map((skill, index) => (
                        <div key={index} className="skill-item" style={{ marginBottom: '15px' }}>
                            <div style={{ 
                                display: 'flex', 
                                justifyContent: 'space-between',
                                marginBottom: '5px'
                            }}>
                                <span style={{ color: '#fff', display: 'flex', alignItems: 'center', gap: '10px' }}>
                                    {skill.icon} {skill.name}
                                </span>
                                <span style={{ color: '#00ff9d' }}>{skill.level}%</span>
                            </div>
                            <div style={{
                                height: '6px',
                                background: 'rgba(255, 255, 255, 0.1)',
                                borderRadius: '3px',
                                overflow: 'hidden'
                            }}>
                                <motion.div
                                    initial={{ width: 0 }}
                                    animate={{ width: `${skill.level}%` }}
                                    transition={{ delay: index * 0.1, duration: 1 }}
                                    style={{
                                        height: '100%',
                                        background: 'linear-gradient(90deg, #00eeff, #ff00ff)',
                                        borderRadius: '3px'
                                    }}
                                />
                            </div>
                        </div>
                    ))}
                </div>
                
                <div className="action-buttons" style={{ marginTop: '20px' }}>
                    <button
                        style={{
                            background: 'transparent',
                            border: '1px solid #00eeff',
                            color: '#00eeff',
                            padding: '10px 20px',
                            borderRadius: '5px',
                            cursor: 'pointer',
                            display: 'flex',
                            alignItems: 'center',
                            gap: '10px',
                            marginRight: '10px'
                        }}
                        onMouseEnter={(e) => {
                            e.target.style.background = '#00eeff';
                            e.target.style.color = '#000';
                        }}
                        onMouseLeave={(e) => {
                            e.target.style.background = 'transparent';
                            e.target.style.color = '#00eeff';
                        }}
                    >
                        <FaDownload /> SCARICA CV
                    </button>
                </div>
            </motion.div>
        </Html>
    );
}

// Componente principale
export default function HologramCard() {
    const [isCardOpen, setIsCardOpen] = useState(false);
    const [isVisible, setIsVisible] = useState(false);

    React.useEffect(() => {
        const timer = setTimeout(() => setIsVisible(true), 1000);
        return () => clearTimeout(timer);
    }, []);

    const toggleCard = () => {
        setIsCardOpen(!isCardOpen);
    };

    return (
        <motion.div
            className="hologram-card-container"
            initial={{ opacity: 0, y: 50 }}
            animate={{ 
                opacity: isVisible ? 1 : 0,
                y: isVisible ? 0 : 50
            }}
            transition={{ duration: 1 }}
            style={{
                position: 'relative',
                width: '100%',
                height: '600px',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}
        >
            <Canvas
                camera={{ position: [0, 0, 10], fov: 50 }}
                style={{ background: 'transparent' }}
            >
                <ambientLight intensity={0.5} />
                <pointLight position={[10, 10, 10]} color="#00eeff" intensity={1} />
                <pointLight position={[-10, -10, -10]} color="#ff00ff" intensity={0.5} />
                
                <Hologram3D isOpen={isCardOpen} toggleCard={toggleCard} />
                <CardContent isOpen={isCardOpen} />
            </Canvas>
            
            {/* Istruzioni */}
            {!isCardOpen && (
                <div style={{
                    position: 'absolute',
                    bottom: '50px',
                    color: '#00eeff',
                    textAlign: 'center',
                    fontSize: '0.9rem',
                    opacity: 0.8,
                    animation: 'pulse 2s infinite'
                }}>
                    CLICCA LA CARD PER ACCEDERE AL PROFILO
                </div>
            )}
        </motion.div>
    );
}