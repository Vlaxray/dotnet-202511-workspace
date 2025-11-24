// components/Hero.js
import React from 'react';

const Hero = () => {
  return (
    <section className="hero">
      <div className="hero-background">
        <div className="gradient-orb orb-1"></div>
        <div className="gradient-orb orb-2"></div>
        <div className="gradient-orb orb-3"></div>
      </div>
      
      <div className="hero-content">
        <div className="hero-text">
          <h1 className="hero-title">
            <span className="title-line">FULL-STACK</span>
            <span className="title-line accent">DEVELOPER</span>
          </h1>
          <p className="hero-subtitle">
            Crafting digital experiences with clean code and modern design
          </p>
          
          <div className="hero-buttons">
            <a href="/cv.pdf" className="btn btn-primary" download>
              <span>Download CV</span>
              <i className="fas fa-download"></i>
            </a>
            <div className="social-links">
              <a href="https://github.com" className="social-link">
                <i className="fab fa-github"></i>
              </a>
              <a href="https://linkedin.com" className="social-link">
                <i className="fab fa-linkedin"></i>
              </a>
              <a href="mailto:hello@example.com" className="social-link">
                <i className="fas fa-envelope"></i>
              </a>
            </div>
          </div>
        </div>
        
        <div className="hero-visual">
          <div className="floating-card code-card">
            <div className="code-line"></div>
            <div className="code-line short"></div>
            <div className="code-line"></div>
          </div>
        </div>
      </div>
      
      <div className="scroll-indicator">
        <div className="scroll-line"></div>
      </div>
    </section>
  );
};

export default Hero;