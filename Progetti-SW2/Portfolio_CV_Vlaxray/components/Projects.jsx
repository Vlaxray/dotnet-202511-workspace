// components/Projects.js
import React from 'react';

const Projects = () => {
  const projects = [
    {
      title: "E-Commerce Platform",
      description: "Full-stack e-commerce solution with React, Node.js, and PostgreSQL",
      tech: ["React", "Node.js", "PostgreSQL", "Stripe"],
      gradient: "gradient-1"
    },
    {
      title: "Data Analytics Dashboard",
      description: "Real-time data visualization platform with interactive charts",
      tech: ["TypeScript", "D3.js", "Python", "FastAPI"],
      gradient: "gradient-2"
    },
    {
      title: "Mobile Task Manager",
      description: "Cross-platform productivity app with offline capabilities",
      tech: ["React Native", "Redux", "Firebase", "GraphQL"],
      gradient: "gradient-3"
    }
  ];

  return (
    <section className="projects">
      <div className="container">
        <div className="section-header">
          <h2 className="section-title">Featured Projects</h2>
          <p className="section-subtitle">A glimpse of my recent work</p>
        </div>
        
        <div className="projects-grid">
          {projects.map((project, index) => (
            <div key={index} className="project-card">
              <div className={`project-gradient ${project.gradient}`}></div>
              <div className="project-content">
                <h3 className="project-title">{project.title}</h3>
                <p className="project-description">{project.description}</p>
                <div className="project-tech">
                  {project.tech.map(tech => (
                    <span key={tech} className="tech-tag">{tech}</span>
                  ))}
                </div>
                <div className="project-links">
                  <button className="project-link">
                    <i className="fab fa-github"></i>
                    Code
                  </button>
                  <button className="project-link">
                    <i className="fas fa-external-link-alt"></i>
                    Live Demo
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
};

export default Projects;