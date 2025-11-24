// components/TechStack.js
import React from 'react';

const TechStack = () => {
  const technologies = [
    { name: 'JavaScript', icon: 'fab fa-js', color: '#f7df1e' },
    { name: 'TypeScript', icon: 'fas fa-code', color: '#3178c6' },
    { name: 'React', icon: 'fab fa-react', color: '#61dafb' },
    { name: 'Node.js', icon: 'fab fa-node-js', color: '#339933' },
    { name: 'Python', icon: 'fab fa-python', color: '#3776ab' },
    { name: 'Go', icon: 'fas fa-code', color: '#00add8' },
    { name: 'Docker', icon: 'fab fa-docker', color: '#2496ed' },
    { name: 'AWS', icon: 'fab fa-aws', color: '#ff9900' },
    { name: 'PostgreSQL', icon: 'fas fa-database', color: '#336791' },
    { name: 'MongoDB', icon: 'fas fa-database', color: '#47a248' },
    { name: 'GraphQL', icon: 'fas fa-project-diagram', color: '#e10098' },
    { name: 'Git', icon: 'fab fa-git-alt', color: '#f05032' }
  ];

  return (
    <section className="tech-stack">
      <div className="container">
        <div className="section-header">
          <h2 className="section-title">Tech Stack</h2>
          <p className="section-subtitle">Technologies I work with</p>
        </div>
        
        <div className="tech-grid">
          {technologies.map((tech, index) => (
            <div 
              key={tech.name}
              className="tech-card"
              style={{ '--delay': index * 0.1 + 's' }}
            >
              <div className="tech-icon" style={{ color: tech.color }}>
                <i className={tech.icon}></i>
              </div>
              <span className="tech-name">{tech.name}</span>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
};

export default TechStack;