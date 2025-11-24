// components/Footer.js
import React from 'react';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="container">
        <div className="footer-content">
          <div className="footer-text">
            <h3>Let's build something amazing together</h3>
            <p>Ready to bring your ideas to life with cutting-edge technology</p>
          </div>
          
          <div className="footer-links">
            <a href="https://github.com" className="footer-link">
              <i className="fab fa-github"></i>
            </a>
            <a href="https://linkedin.com" className="footer-link">
              <i className="fab fa-linkedin"></i>
            </a>
            <a href="mailto:hello@example.com" className="footer-link">
              <i className="fas fa-envelope"></i>
            </a>
            <a href="/cv.pdf" className="footer-link" download>
              <i className="fas fa-file-alt"></i>
            </a>
          </div>
        </div>
        
        <div className="footer-bottom">
          <p>&copy; 2024 Developer Portfolio. Crafted with passion.</p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;