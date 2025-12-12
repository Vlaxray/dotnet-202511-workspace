// src/components/FolderSystem.jsx
import React, { useState, useEffect, useRef } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { 
    FaFolder, 
    FaFolderOpen, 
    FaCode, 
    FaBriefcase, 
    FaGraduationCap,
    FaProjectDiagram,
    FaTools,
    FaCertificate,
    FaExternalLinkAlt,
    FaCalendarAlt,
    FaMapMarkerAlt
} from 'react-icons/fa';
import { usePerformance } from './PerformanceWrapper';
import './FolderSystem.css';
// Dati per le cartelle
const foldersData = [
    {
        id: 'experience',
        title: 'ESPERIENZE LAVORATIVE',
        icon: <FaBriefcase />,
        color: '#00eeff',
        items: [
            {
                id: 1,
                title: 'Lead Full-Stack Developer',
                company: 'NeonCorp Technologies',
                period: '2022 - Presente',
                location: 'Milano, Italia',
                description: 'Sviluppo di applicazioni web avanzate con React, Node.js e Three.js. Gestione di team di sviluppo e architettura di sistemi distribuiti.',
                technologies: ['React', 'Three.js', 'Node.js', 'MongoDB', 'AWS', 'Docker'],
                achievements: [
                    'Riduzione del 40% del tempo di caricamento delle applicazioni',
                    'Implementazione di sistemi di sicurezza avanzati',
                    'Formazione di 5 sviluppatori junior'
                ]
            },
            {
                id: 2,
                title: 'Cybersecurity Specialist',
                company: 'Digital Fortress',
                period: '2020 - 2022',
                location: 'Roma, Italia',
                description: 'Analisi e implementazione di sistemi di sicurezza per applicazioni enterprise. Penetration testing e hardening di infrastrutture cloud.',
                technologies: ['Python', 'Kubernetes', 'Docker', 'AWS Security', 'SIEM'],
                achievements: [
                    'Riduzione del 95% delle vulnerabilità critiche',
                    'Implementazione di sistema di monitoraggio 24/7',
                    'Certificazione ISO 27001 ottenuta'
                ]
            },
            {
                id: 3,
                title: 'Frontend Developer',
                company: 'CyberDreams Agency',
                period: '2018 - 2020',
                location: 'Torino, Italia',
                description: 'Sviluppo di interfacce utente innovative per clienti internazionali. Focus su UX/UI e performance optimization.',
                technologies: ['React', 'Vue.js', 'WebGL', 'SASS', 'Webpack'],
                achievements: [
                    'Premio "Best UI Design 2019"',
                    'Miglioramento delle performance del 60%',
                    '5 progetti completati con successo'
                ]
            }
        ]
    },
    {
        id: 'projects',
        title: 'PROGETTI CYBERPUNK',
        icon: <FaProjectDiagram />,
        color: '#ff00ff',
        items: [
            {
                id: 1,
                title: 'Neural Interface',
                year: '2023',
                status: 'In Sviluppo',
                description: 'Interfaccia neurale per controllo di dispositivi IoT tramite onde cerebrali e machine learning.',
                technologies: ['Python', 'TensorFlow', 'React Native', 'MQTT', 'WebSocket'],
                features: [
                    'Riconoscimento pattern cerebrali in tempo reale',
                    'Controllo di 20+ dispositivi IoT',
                    'Accuracy del 98.7%'
                ],
                github: 'https://github.com/yourusername/neural-interface',
                demo: 'https://demo.neuralinterface.com'
            },
            {
                id: 2,
                title: 'Holographic CV',
                year: '2023',
                status: 'Completato',
                description: 'Portfolio interattivo con elementi 3D olografici e effetti cyberpunk.',
                technologies: ['React', 'Three.js', 'Framer Motion', 'WebGL', 'GSAP'],
                features: [
                    'Renderizzazione 3D in tempo reale',
                    'Interazioni gestuali',
                    'Performance ottimizzate per mobile'
                ],
                github: 'https://github.com/yourusername/holographic-cv',
                demo: 'https://cyberportfolio.dev'
            },
            {
                id: 3,
                title: 'Quantum Cryptography',
                year: '2022',
                status: 'In Produzione',
                description: 'Sistema di crittografia quantistica per comunicazioni sicure.',
                technologies: ['Python', 'Qiskit', 'Node.js', 'PostgreSQL', 'Redis'],
                features: [
                    'Crittografia AES-512',
                    'Key distribution quantistica',
                    'Zero-knowledge proofs'
                ]
            }
        ]
    },
    {
        id: 'education',
        title: 'FORMAZIONE & CERTIFICAZIONI',
        icon: <FaGraduationCap />,
        color: '#00ff9d',
        items: [
            {
                id: 1,
                degree: 'Laurea Magistrale in Computer Science',
                institution: 'Politecnico di Milano',
                period: '2016 - 2019',
                grade: '110/110 con Lode',
                thesis: 'Realtà Aumentata e Interfacce Neurali: Nuove Frontiere dell\'Interazione Uomo-Macchina',
                courses: [
                    'Intelligenza Artificiale Avanzata',
                    'Computer Graphics & VR',
                    'Cybersecurity',
                    'Distributed Systems'
                ]
            },
            {
                id: 2,
                degree: 'Certificazione AWS Solutions Architect',
                institution: 'Amazon Web Services',
                period: '2021',
                credential: 'SAA-C03',
                validUntil: '2024'
            },
            {
                id: 3,
                degree: 'Certificazione Ethical Hacker',
                institution: 'EC-Council',
                period: '2020',
                credential: 'CEH v11'
            }
        ]
    },
    {
        id: 'skills',
        title: 'COMPETENZE TECNICHE',
        icon: <FaTools />,
        color: '#ff9900',
        items: [
            {
                category: 'Frontend',
                skills: [
                    { name: 'React/Next.js', level: 95 },
                    { name: 'Three.js/WebGL', level: 90 },
                    { name: 'TypeScript', level: 88 },
                    { name: 'Vue.js', level: 75 }
                ]
            },
            {
                category: 'Backend',
                skills: [
                    { name: 'Node.js/Express', level: 92 },
                    { name: 'Python/Django', level: 85 },
                    { name: 'MongoDB', level: 88 },
                    { name: 'PostgreSQL', level: 82 }
                ]
            },
            {
                category: 'DevOps & Cloud',
                skills: [
                    { name: 'Docker/Kubernetes', level: 80 },
                    { name: 'AWS/GCP', level: 85 },
                    { name: 'CI/CD', level: 78 },
                    { name: 'Linux/Unix', level: 90 }
                ]
            },
            {
                category: 'Cybersecurity',
                skills: [
                    { name: 'Penetration Testing', level: 88 },
                    { name: 'Network Security', level: 85 },
                    { name: 'Cryptography', level: 82 },
                    { name: 'SIEM/SOC', level: 78 }
                ]
            }
        ]
    }
];

// Componente Folder
const Folder = ({ folder, isOpen, onClick }) => {
    return (
        <motion.div
            className={`cyber-folder ${isOpen ? 'open' : ''}`}
            onClick={onClick}
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            whileHover={{ scale: 1.05, y: -5 }}
            whileTap={{ scale: 0.95 }}
            style={{
                '--folder-color': folder.color
            }}
        >
            <div className="folder-icon" style={{ color: folder.color }}>
                {isOpen ? <FaFolderOpen /> : <FaFolder />}
            </div>
            <h3 className="folder-title">{folder.title}</h3>
            <div className="folder-status">
                <span className="status-indicator" style={{ backgroundColor: folder.color }} />
                <span className="status-text">ACCESSO {isOpen ? 'ATTIVO' : 'DISPONIBILE'}</span>
            </div>
            <div className="folder-items-count">
                <span>{folder.items.length} ITEMS</span>
            </div>
        </motion.div>
    );
};

// Componente per il contenuto delle esperienze
const ExperienceContent = ({ item }) => {
    return (
        <motion.div
            className="content-item experience"
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: 20 }}
        >
            <div className="content-header">
                <div className="header-left">
                    <h4 className="item-title">{item.title}</h4>
                    <div className="item-company">{item.company}</div>
                </div>
                <div className="header-right">
                    <div className="item-period">
                        <FaCalendarAlt /> {item.period}
                    </div>
                    <div className="item-location">
                        <FaMapMarkerAlt /> {item.location}
                    </div>
                </div>
            </div>
            
            <p className="item-description">{item.description}</p>
            
            <div className="technologies-section">
                <h5>Tecnologie Utilizzate:</h5>
                <div className="tech-tags">
                    {item.technologies.map((tech, index) => (
                        <span key={index} className="tech-tag">{tech}</span>
                    ))}
                </div>
            </div>
            
            <div className="achievements-section">
                <h5>Risultati Raggiunti:</h5>
                <ul className="achievements-list">
                    {item.achievements.map((achievement, index) => (
                        <li key={index} className="achievement-item">
                            <span className="achievement-bullet">▸</span>
                            {achievement}
                        </li>
                    ))}
                </ul>
            </div>
        </motion.div>
    );
};

// Componente per il contenuto dei progetti
const ProjectContent = ({ item }) => {
    return (
        <motion.div
            className="content-item project"
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: 20 }}
        >
            <div className="content-header">
                <div className="header-left">
                    <h4 className="item-title">{item.title}</h4>
                    <div className="item-year">{item.year}</div>
                </div>
                <div className="header-right">
                    <div className={`item-status ${item.status.toLowerCase().replace(' ', '-')}`}>
                        {item.status}
                    </div>
                </div>
            </div>
            
            <p className="item-description">{item.description}</p>
            
            <div className="project-details">
                <div className="technologies-section">
                    <h5>Stack Tecnologico:</h5>
                    <div className="tech-tags">
                        {item.technologies.map((tech, index) => (
                            <span key={index} className="tech-tag">{tech}</span>
                        ))}
                    </div>
                </div>
                
                <div className="features-section">
                    <h5>Caratteristiche Principali:</h5>
                    <ul className="features-list">
                        {item.features.map((feature, index) => (
                            <li key={index} className="feature-item">
                                <span className="feature-icon">⚡</span>
                                {feature}
                            </li>
                        ))}
                    </ul>
                </div>
                
                {(item.github || item.demo) && (
                    <div className="project-links">
                        {item.github && (
                            <a 
                                href={item.github} 
                                target="_blank" 
                                rel="noopener noreferrer"
                                className="project-link github"
                            >
                                <FaCode /> Codice Sorgente
                            </a>
                        )}
                        {item.demo && (
                            <a 
                                href={item.demo} 
                                target="_blank" 
                                rel="noopener noreferrer"
                                className="project-link demo"
                            >
                                <FaExternalLinkAlt /> Demo Live
                            </a>
                        )}
                    </div>
                )}
            </div>
        </motion.div>
    );
};

// Componente per il contenuto della formazione
const EducationContent = ({ item }) => {
    return (
        <motion.div
            className="content-item education"
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: 20 }}
        >
            <div className="content-header">
                <h4 className="item-title">{item.degree}</h4>
                <div className="item-institution">{item.institution}</div>
            </div>
            
            <div className="education-details">
                <div className="detail-row">
                    <span className="detail-label">Periodo:</span>
                    <span className="detail-value">{item.period}</span>
                </div>
                
                {item.grade && (
                    <div className="detail-row">
                        <span className="detail-label">Voto:</span>
                        <span className="detail-value grade">{item.grade}</span>
                    </div>
                )}
                
                {item.credential && (
                    <div className="detail-row">
                        <span className="detail-label">Certificazione:</span>
                        <span className="detail-value credential">{item.credential}</span>
                    </div>
                )}
                
                {item.thesis && (
                    <div className="thesis-section">
                        <h5>Tesi di Laurea:</h5>
                        <p className="thesis-title">{item.thesis}</p>
                    </div>
                )}
                
                {item.courses && (
                    <div className="courses-section">
                        <h5>Corsi Principali:</h5>
                        <div className="course-tags">
                            {item.courses.map((course, index) => (
                                <span key={index} className="course-tag">{course}</span>
                            ))}
                        </div>
                    </div>
                )}
            </div>
        </motion.div>
    );
};

// Componente per il contenuto delle skills
const SkillsContent = ({ item }) => {
    return (
        <motion.div
            className="content-item skills"
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: 20 }}
        >
            <h4 className="skills-category">{item.category}</h4>
            
            <div className="skills-grid">
                {item.skills.map((skill, index) => (
                    <div key={index} className="skill-item">
                        <div className="skill-header">
                            <span className="skill-name">{skill.name}</span>
                            <span className="skill-percentage">{skill.level}%</span>
                        </div>
                        <div className="skill-bar">
                            <motion.div 
                                className="skill-progress"
                                initial={{ width: 0 }}
                                animate={{ width: `${skill.level}%` }}
                                transition={{ 
                                    delay: index * 0.1, 
                                    duration: 1,
                                    type: "spring",
                                    stiffness: 100
                                }}
                                style={{ 
                                    background: `linear-gradient(90deg, 
                                        var(--folder-color) 0%,
                                        ${getContrastColor()} 100%)`
                                }}
                            />
                        </div>
                    </div>
                ))}
            </div>
        </motion.div>
    );
};

// Helper function per colori
const getContrastColor = () => {
    const colors = ['#00eeff', '#ff00ff', '#00ff9d', '#ff9900'];
    return colors[Math.floor(Math.random() * colors.length)];
};

// Componente principale FolderSystem
export default function FolderSystem() {
    const [activeFolder, setActiveFolder] = useState(null);
    const [contentIndex, setContentIndex] = useState(0);
    const containerRef = useRef(null);
    const { isMobile } = usePerformance();

    // Funzione per cambiare cartella
    const handleFolderClick = (folderId) => {
        if (activeFolder === folderId) {
            setActiveFolder(null);
        } else {
            setActiveFolder(folderId);
            setContentIndex(0);
        }
    };

    // Funzione per cambiare contenuto
    const handleNextContent = () => {
        const currentFolder = foldersData.find(f => f.id === activeFolder);
        if (currentFolder && contentIndex < currentFolder.items.length - 1) {
            setContentIndex(prev => prev + 1);
        }
    };

    const handlePrevContent = () => {
        if (contentIndex > 0) {
            setContentIndex(prev => prev - 1);
        }
    };

    // Renderizza il contenuto in base al tipo di cartella
    const renderContent = () => {
        const folder = foldersData.find(f => f.id === activeFolder);
        if (!folder) return null;

        const item = folder.items[contentIndex];
        
        switch(folder.id) {
            case 'experience':
                return <ExperienceContent item={item} />;
            case 'projects':
                return <ProjectContent item={item} />;
            case 'education':
                return <EducationContent item={item} />;
            case 'skills':
                return <SkillsContent item={item} />;
            default:
                return null;
        }
    };

    return (
        <div className="folder-system" ref={containerRef}>
            {/* Grid delle cartelle */}
            <div className={`folders-grid ${isMobile ? 'mobile' : ''}`}>
                {foldersData.map((folder) => (
                    <Folder
                        key={folder.id}
                        folder={folder}
                        isOpen={activeFolder === folder.id}
                        onClick={() => handleFolderClick(folder.id)}
                    />
                ))}
            </div>

            {/* Contenuto della cartella attiva */}
            <AnimatePresence>
                {activeFolder && (
                    <motion.div
                        className="folder-content-container"
                        initial={{ opacity: 0, height: 0 }}
                        animate={{ opacity: 1, height: 'auto' }}
                        exit={{ opacity: 0, height: 0 }}
                    >
                        <div className="folder-content">
                            {/* Header del contenuto */}
                            <div className="content-header-section">
                                <h3 className="content-title">
                                    {foldersData.find(f => f.id === activeFolder)?.title}
                                </h3>
                                
                                <div className="content-navigation">
                                    <button 
                                        className="nav-button prev"
                                        onClick={handlePrevContent}
                                        disabled={contentIndex === 0}
                                    >
                                        ←
                                    </button>
                                    
                                    <div className="content-counter">
                                        <span className="current-index">{contentIndex + 1}</span>
                                        <span className="total-items">
                                            /{foldersData.find(f => f.id === activeFolder)?.items.length}
                                        </span>
                                    </div>
                                    
                                    <button 
                                        className="nav-button next"
                                        onClick={handleNextContent}
                                        disabled={
                                            contentIndex === 
                                            foldersData.find(f => f.id === activeFolder)?.items.length - 1
                                        }
                                    >
                                        →
                                    </button>
                                </div>
                            </div>

                            {/* Contenuto dinamico */}
                            <div className="content-body">
                                <AnimatePresence mode="wait">
                                    {renderContent()}
                                </AnimatePresence>
                            </div>
                        </div>
                    </motion.div>
                )}
            </AnimatePresence>
        </div>
    );
}