// src/components/CyberTerminal.jsx
import React, { useState, useRef, useEffect } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { FaTerminal, FaTimes, FaPlay, FaFolderOpen } from 'react-icons/fa';

const CyberTerminal = () => {
    const [isOpen, setIsOpen] = useState(false);
    const [input, setInput] = useState('');
    const [history, setHistory] = useState([]);
    const [output, setOutput] = useState([]);
    const terminalRef = useRef(null);
    const inputRef = useRef(null);

    // Comandi disponibili
    const commands = {
        help: {
            desc: 'Mostra tutti i comandi disponibili',
            execute: () => [
                '╔════════════════════════════════════════╗',
                '║          CYBER TERMINAL v2.5           ║',
                '╠════════════════════════════════════════╣',
                '║ help      - Mostra questa lista        ║',
                '║ clear     - Pulisce il terminale       ║',
                '║ bio       - Mostra la biografia        ║',
                '║ skills    - Mostra le competenze       ║',
                '║ projects  - Mostra i progetti          ║',
                '║ contact   - Informazioni di contatto   ║',
                '║ system    - Info sistema               ║',
                '║ matrix    - Effetto Matrix             ║',
                '╚════════════════════════════════════════╝'
            ]
        },
        clear: {
            desc: 'Pulisce il terminale',
            execute: () => {
                setOutput([]);
                return [];
            }
        },
        bio: {
            desc: 'Mostra la biografia',
            execute: () => [
                '╔════════════════════════════════════════╗',
                '║           BIOGRAFIA                    ║',
                '╠════════════════════════════════════════╣',
                '║ Nome: Alex Rogue                       ║',
                '║ Ruolo: Full-Stack Developer            ║',
                '║ Specializzazione: Cybersecurity        ║',
                '║                                        ║',
                '║ Esperto in sviluppo di interfacce     ║',
                '║ immersive e sistemi sicuri. Combinando║',
                '║ estetica cyberpunk con funzionalità   ║',
                '║ all\'avanguardia.                     ║',
                '╚════════════════════════════════════════╝'
            ]
        },
        skills: {
            desc: 'Mostra le competenze',
            execute: () => [
                '╔════════════════════════════════════════╗',
                '║          COMPETENZE                    ║',
                '╠════════════════════════════════════════╣',
                '║ [██████████] React/Three.js - 95%      ║',
                '║ [█████████ ] Cybersecurity - 88%       ║',
                '║ [████████  ] Database - 82%            ║',
                '║ [███████   ] DevOps - 78%              ║',
                '║ [████████  ] UI/UX - 85%               ║',
                '║ [███████   ] AI/ML - 76%               ║',
                '╚════════════════════════════════════════╝'
            ]
        },
        system: {
            desc: 'Informazioni di sistema',
            execute: () => [
                '╔════════════════════════════════════════╗',
                '║          STATUS SISTEMA                ║',
                '╠════════════════════════════════════════╣',
                '║ Sistema:   CyberPortfolio OS v2.5.1    ║',
                '║ CPU:       3.8 GHz Neural Processor    ║',
                '║ RAM:       32GB Quantum Memory         ║',
                '║ Storage:   1TB Holographic Drive       ║',
                '║ Network:   10Gb/s Quantum Link         ║',
                '║ Security:  AES-512 Encryption          ║',
                '║ Status:    [ONLINE]                    ║',
                '╚════════════════════════════════════════╝'
            ]
        },
        matrix: {
            desc: 'Effetto Matrix',
            execute: () => {
                // Simula effetto Matrix
                const matrixLines = [];
                for (let i = 0; i < 10; i++) {
                    const line = Array.from({length: 40}, () => 
                        Math.random() > 0.5 ? '1' : '0'
                    ).join('');
                    matrixLines.push(line);
                }
                return ['Effetto Matrix attivato...', ...matrixLines];
            }
        }
    };

    const executeCommand = (cmd) => {
        const trimmedCmd = cmd.trim().toLowerCase();
        setHistory([...history, `$ ${cmd}`]);
        
        if (commands[trimmedCmd]) {
            const result = commands[trimmedCmd].execute();
            if (Array.isArray(result) && result.length > 0) {
                setOutput([...output, ...result]);
            }
        } else if (trimmedCmd) {
            setOutput([...output, `Comando non trovato: ${cmd}`]);
        }
        
        setInput('');
    };

    // Auto-scroll
    useEffect(() => {
        if (terminalRef.current) {
            terminalRef.current.scrollTop = terminalRef.current.scrollHeight;
        }
    }, [output]);

    // Focus sull'input quando il terminale si apre
    useEffect(() => {
        if (isOpen && inputRef.current) {
            setTimeout(() => inputRef.current.focus(), 100);
        }
    }, [isOpen]);

    return (
        <>
            {/* Bottone per aprire il terminale */}
            <motion.button
                className="terminal-toggle"
                onClick={() => setIsOpen(true)}
                initial={{ x: 50, opacity: 0 }}
                animate={{ x: 0, opacity: 1 }}
                transition={{ delay: 1.5, duration: 0.5 }}
                style={{
                    position: 'fixed',
                    bottom: '20px',
                    right: '20px',
                    zIndex: 1000,
                    background: 'linear-gradient(45deg, #001122, #003344)',
                    border: '2px solid #00eeff',
                    color: '#00eeff',
                    padding: '15px 20px',
                    borderRadius: '5px',
                    cursor: 'pointer',
                    display: 'flex',
                    alignItems: 'center',
                    gap: '10px',
                    fontFamily: 'monospace',
                    fontWeight: 'bold',
                    boxShadow: '0 0 15px rgba(0, 238, 255, 0.5)'
                }}
                whileHover={{ scale: 1.05 }}
                whileTap={{ scale: 0.95 }}
            >
                <FaTerminal /> APRI TERMINALE
            </motion.button>

            {/* Terminale */}
            <AnimatePresence>
                {isOpen && (
                    <motion.div
                        className="terminal-modal"
                        initial={{ opacity: 0, y: '100%' }}
                        animate={{ opacity: 1, y: 0 }}
                        exit={{ opacity: 0, y: '100%' }}
                        style={{
                            position: 'fixed',
                            bottom: 0,
                            left: 0,
                            right: 0,
                            height: '70vh',
                            background: 'rgba(0, 10, 20, 0.98)',
                            backdropFilter: 'blur(10px)',
                            borderTop: '3px solid #00eeff',
                            zIndex: 1001,
                            boxShadow: '0 0 50px rgba(0, 238, 255, 0.3)'
                        }}
                    >
                        {/* Header del terminale */}
                        <div style={{
                            display: 'flex',
                            justifyContent: 'space-between',
                            alignItems: 'center',
                            padding: '15px 20px',
                            background: 'rgba(0, 30, 60, 0.8)',
                            borderBottom: '1px solid #00eeff'
                        }}>
                            <div style={{ display: 'flex', alignItems: 'center', gap: '10px' }}>
                                <FaTerminal style={{ color: '#00eeff' }} />
                                <span style={{ 
                                    color: '#00eeff',
                                    fontFamily: 'monospace',
                                    fontWeight: 'bold'
                                }}>
                                    NEURAL_TERMINAL v2.5
                                </span>
                            </div>
                            <button
                                onClick={() => setIsOpen(false)}
                                style={{
                                    background: 'transparent',
                                    border: '1px solid #ff0066',
                                    color: '#ff0066',
                                    width: '30px',
                                    height: '30px',
                                    borderRadius: '50%',
                                    cursor: 'pointer',
                                    display: 'flex',
                                    alignItems: 'center',
                                    justifyContent: 'center'
                                }}
                            >
                                <FaTimes />
                            </button>
                        </div>

                        {/* Corpo del terminale */}
                        <div
                            ref={terminalRef}
                            style={{
                                height: 'calc(100% - 120px)',
                                padding: '20px',
                                overflowY: 'auto',
                                fontFamily: 'monospace',
                                fontSize: '0.9rem',
                                lineHeight: '1.4',
                                color: '#00ff9d'
                            }}
                        >
                            {/* Messaggio di benvenuto */}
                            <div style={{ marginBottom: '20px' }}>
                                <div style={{ color: '#00eeff', marginBottom: '10px' }}>
                                    ╔════════════════════════════════════════╗
                                </div>
                                <div style={{ color: '#00eeff', marginBottom: '5px' }}>
                                    ║    CYBER PORTFOLIO TERMINAL v2.5      ║
                                </div>
                                <div style={{ color: '#00eeff', marginBottom: '10px' }}>
                                    ╚════════════════════════════════════════╝
                                </div>
                                <div style={{ marginBottom: '10px' }}>
                                    Digita 'help' per la lista dei comandi
                                </div>
                            </div>

                            {/* Cronologia comandi */}
                            {history.map((cmd, index) => (
                                <div key={index} style={{ marginBottom: '5px' }}>
                                    <span style={{ color: '#ff00ff' }}>{cmd}</span>
                                </div>
                            ))}

                            {/* Output */}
                            {output.map((line, index) => (
                                <div key={index} style={{ 
                                    marginBottom: '2px',
                                    color: line.startsWith('║') ? '#00eeff' : '#00ff9d'
                                }}>
                                    {line}
                                </div>
                            ))}
                        </div>

                        {/* Input del terminale */}
                        <div style={{
                            padding: '15px 20px',
                            background: 'rgba(0, 20, 40, 0.9)',
                            borderTop: '1px solid #00eeff'
                        }}>
                            <div style={{ display: 'flex', alignItems: 'center', gap: '10px' }}>
                                <span style={{ color: '#ff00ff' }}>$</span>
                                <input
                                    ref={inputRef}
                                    type="text"
                                    value={input}
                                    onChange={(e) => setInput(e.target.value)}
                                    onKeyDown={(e) => {
                                        if (e.key === 'Enter') {
                                            executeCommand(input);
                                        }
                                    }}
                                    style={{
                                        flex: 1,
                                        background: 'transparent',
                                        border: 'none',
                                        color: '#00ff9d',
                                        fontFamily: 'monospace',
                                        fontSize: '0.9rem',
                                        outline: 'none'
                                    }}
                                    placeholder="Digita un comando..."
                                />
                                <button
                                    onClick={() => executeCommand(input)}
                                    style={{
                                        background: 'transparent',
                                        border: '1px solid #00eeff',
                                        color: '#00eeff',
                                        padding: '8px 15px',
                                        borderRadius: '3px',
                                        cursor: 'pointer',
                                        display: 'flex',
                                        alignItems: 'center',
                                        gap: '5px'
                                    }}
                                >
                                    <FaPlay /> Esegui
                                </button>
                            </div>
                        </div>
                    </motion.div>
                )}
            </AnimatePresence>
        </>
    );
};

export default CyberTerminal;