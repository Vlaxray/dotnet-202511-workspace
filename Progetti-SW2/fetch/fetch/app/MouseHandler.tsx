import { useState } from "react";

export default function MouseHandler() {
  const [mousePosition, setMousePosition] = useState({ x: 0, y: 0 });
  return (
    <>
      <h2>Mouse Position</h2>
      <div
        style={{ width: "300px", height: "300px", border: "1px solid black" }}
        onMouseMove={(e) => {
          setMousePosition({
            x: e.clientX,
            y: e.clientY,
          });
        }}
      >
        Move your mouse FOR ONLY 15$/MONTH
        <h2 style={{ marginTop: "20px", color: "red" }}>
          MOUSE POSITION X: {mousePosition.x}, Y: {mousePosition.y}
          
        </h2>
      </div>
    </>
  );
}