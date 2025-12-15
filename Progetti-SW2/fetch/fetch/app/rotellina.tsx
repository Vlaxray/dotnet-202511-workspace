import { useState, useEffect } from "react";

export default function WheelImage() {
  const [showImage, setShowImage] = useState(false);

  useEffect(() => {
    const handleWheel = () => {
      setShowImage(true);
      const timeout = setTimeout(() => setShowImage(false), 3000);
      return () => clearTimeout(timeout);
    };
    window.addEventListener("wheel", handleWheel);
    return () => {
      window.removeEventListener("wheel", handleWheel);
    };
  }, []);

  return (
    <div
      style={{
        width: "400px",
        height: "300px",
        border: "2px solid black",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        overflow: "hidden",
        margin: "50px auto",
        position: "relative",
      }}
    >
      {showImage && (
        <img
          src="https://cdn2.portableapps.com/IrfanViewPortable.png"
          alt="Rotellina attiva"
          style={{ width: "150px", height: "150px", position: "absolute" }}
        />
      )}
      {!showImage && <p>Muovi la rotellina per vedere l immagine</p>}
    </div>
  );
}
