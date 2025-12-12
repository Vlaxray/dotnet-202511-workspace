// src/App.js
import React, { Suspense, lazy, useState, useEffect } from 'react';
import { 
    PerformanceWrapper, 
    LazyLoadComponent, 
    DebouncedComponent,
    PerformanceMonitor 
} from './components/PerformanceWrapper';
import { usePerformanceOptimization } from './utils/performance';
import './styles/Performance.css';

// Componenti caricati in modo lazy
const ThreeDScene = lazy(() => import('./components/OptimizedThreeDScene'));
const HologramCard = lazy(() => import('./components/HologramCard'));
const CyberTerminal = lazy(() => import('./components/CyberTerminal'));
const NeuralGrid = lazy(() => import('./components/NeuralGrid'));
const FolderSystem = lazy(() => import('./components/FolderSystem'));

function App() {
    const [isLoaded, setIsLoaded] = useState(false);
    const [loadingProgress, setLoadingProgress] = useState(0);
    
    // Attiva ottimizzazioni globali
    usePerformanceOptimization(true);
    
    useEffect(() => {
        // Simula caricamento progressivo
        const interval = setInterval(() => {
            setLoadingProgress(prev => {
                const increment = Math.random() * 15 + 5; // 5-20%
                const newProgress = Math.min(prev + increment, 100);
                
                if (newProgress >= 100) {
                    clearInterval(interval);
                    setTimeout(() => setIsLoaded(true), 300);
                    return 100;
                }
                return newProgress;
            });
        }, 200);
        
        return () => clearInterval(interval);
    }, []);
    
    if (!isLoaded) {
        return (
            <div className="cyber-loading-screen">
                <div className="loading-progress">
                    <div className="progress-track">
                        <div 
                            className="progress-bar" 
                            style={{ width: `${loadingProgress}%` }}
                        />
                    </div>
                    <div className="loading-text">
                        INIZIALIZZAZIONE SISTEMA NEURALE... {Math.round(loadingProgress)}%
                    </div>
                    <div className="loading-subtext">
                        <span className="blink">█</span> CRITTOGRAFIA AES-512 ATTIVA
                    </div>
                    <div className="system-info">
                        <div className="system-stat">
                            <span className="stat-label">RAM:</span>
                            <span className="stat-value">{(loadingProgress * 0.32).toFixed(1)}/32GB</span>
                        </div>
                        <div className="system-stat">
                            <span className="stat-label">CPU:</span>
                            <span className="stat-value">{Math.round(loadingProgress * 0.38)}%</span>
                        </div>
                    </div>
                </div>
                
                {/* Effetto particelle nel loading */}
                <div className="loading-particles">
                    {[...Array(20)].map((_, i) => (
                        <div 
                            key={i}
                            className="loading-particle"
                            style={{
                                left: `${Math.random() * 100}%`,
                                animationDelay: `${Math.random() * 2}s`,
                                animationDuration: `${1 + Math.random() * 2}s`
                            }}
                        />
                    ))}
                </div>
            </div>
        );
    }
    
    return (
        <PerformanceWrapper enable3D={true}>
            <PerformanceMonitor componentName="App" logMount={true} />
            
            <div className="cyberpunk-app">
                {/* Effetto scanlines globale */}
                <div className="global-scanlines" />
                
                {/* Grid neurale con lazy loading */}
                <LazyLoadComponent 
                    threshold={0.05}
                    placeholder={
                        <div className="neural-grid-placeholder">
                            <div className="placeholder-grid" />
                        </div>
                    }
                >
                    <Suspense fallback={
                        <div className="threejs-loading">
                            <div className="hologram-loader" />
                        </div>
                    }>
                        <NeuralGrid />
                          <FolderSystem />
                    </Suspense>
                </LazyLoadComponent>
                
                {/* Contenuto principale */}
                <main className="main-content">
                    {/* Header */}
                    <header className="cyber-header">
                        <div className="header-content">
                            <h1 className="logo glitch" data-text="CYBER_PORTFOLIO">
                                CYBER_PORTFOLIO
                            </h1>
                            <div className="header-stats">
                                <div className="stat online">
                                    <span className="status-led" />
                                    <span className="stat-text">SISTEMA ONLINE</span>
                                </div>
                                <div className="stat version">
                                    <span className="stat-text">v2.5.1</span>
                                </div>
                            </div>
                        </div>
                    </header>
                    
                    {/* Scene 3D con debouncing */}
                    <DebouncedComponent delay={500}>
                        <Suspense fallback={
                            <div className="scene-loading">
                                <div className="hologram-spinner" />
                            </div>
                        }>
                            <ThreeDScene />
                        </Suspense>
                    </DebouncedComponent>
                    
                    {/* Card olografica principale */}
                    <section className="hero-section">
                        <Suspense fallback={
                            <div className="card-loading">
                                <div className="hologram-placeholder" />
                            </div>
                        }>
                            <HologramCard />
                        </Suspense>
                    </section>
                    
                    {/* Sistema a cartelle */}
                    <section className="folders-section">
                        <h2 className="section-title glitch" data-text="// ESPERIENZE">
                            // ESPERIENZE
                        </h2>
                        <LazyLoadComponent threshold={0.3}>
                            <Suspense fallback={
                                <div className="folders-loading">
                                    <div className="folder-placeholder" />
                                    <div className="folder-placeholder" />
                                    <div className="folder-placeholder" />
                                </div>
                            }>
                                <FolderSystem />
                            </Suspense>
                        </LazyLoadComponent>
                    </section>
                    
                    {/* Terminale */}
                    <DebouncedComponent delay={1000}>
                        <Suspense fallback={null}>
                            <CyberTerminal />
                        </Suspense>
                    </DebouncedComponent>
                </main>
                
                {/* Footer */}
                <footer className="cyber-footer">
                    <div className="footer-content">
                        <div className="encryption-status">
                            <span className="status-led active" />
                            <span className="status-text">CONNESSIONE SICURA • AES-512</span>
                        </div>
                        <div className="copyright">
                            © {new Date().getFullYear()} CYBER PORTFOLIO v2.5 • SISTEMA NEURALE ATTIVO
                        </div>
                        <div className="performance-info">
                            <span className="perf-stat">FPS: 60</span>
                            <span className="perf-stat">RAM: 24.3/32GB</span>
                            <span className="perf-stat">GPU: ACTIVE</span>
                        </div>
                    </div>
                </footer>
            </div>
        </PerformanceWrapper>
    );
}

export default App;