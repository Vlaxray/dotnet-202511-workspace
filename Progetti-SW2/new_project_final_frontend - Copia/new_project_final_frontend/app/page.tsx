"use client";

import { useState } from "react";
import Prodotti from "./Prodotti";

type Meal = {
  id: string;
  name: string;
  category: string;
  area: string;
  instructions: string;
  thumbnail: string;
};

export default function Home() {
  const [query, setQuery] = useState("");
  const [meal, setMeal] = useState<Meal | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSearch = async () => {
    if (!query.trim()) return;

    setLoading(true);
    setError(null);

    try {
      const res = await fetch("http://localhost:5000/api/meals/search", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ query }),
      });

      if (!res.ok) {
        throw new Error("Errore API");
      }

      const data: Meal = await res.json();
      setMeal(data);
    } catch {
      setError("Piatto non trovato");
      setMeal(null);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex min-h-screen items-center justify-center bg-zinc-50">
      <main className="w-full max-w-3xl py-32 px-16 bg-white text-center">

        {/* INPUT */}
        <input
          type="text"
          className="form-control mb-3"
          placeholder="Scrivi il nome del piatto (es. Arrabbiata)"
          value={query}
          onChange={(e) => setQuery(e.target.value)}
          onKeyDown={(e) => {
            if (e.key === "Enter") handleSearch();
          }}
        />

        {/* BOTTONE */}
        <button
          type="button"
          className="btn btn-success mb-4"
          onClick={handleSearch}
        >
          Cerca
        </button>

        {/* STATI */}
        {loading && <p>Caricamento...</p>}
        {error && <p className="text-danger">{error}</p>}

        {/* RISULTATO */}
        {meal && <Prodotti meal={meal} />}

      </main>
    </div>
  );
}
