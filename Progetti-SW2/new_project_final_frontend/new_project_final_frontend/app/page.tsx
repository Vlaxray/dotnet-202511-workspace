"use client";

import { useState, useEffect } from "react";
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
  const [suggestions, setSuggestions] = useState<string[]>([]);
  const [meal, setMeal] = useState<Meal | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // 🔹 AUTOCOMPLETE (solo DB)
  useEffect(() => {
    if (query.trim().length < 1) {
      setSuggestions([]);
      return;
    }

    const timeout = setTimeout(async () => {
      try {
        const res = await fetch(
          `http://localhost:5000/api/meals/suggest?q=${query}`
        );

        if (res.ok) {
          const data: string[] = await res.json();
          setSuggestions(data);
        }
      } catch {
        setSuggestions([]);
      }
    }, 300); // debounce 300ms

    return () => clearTimeout(timeout);
  }, [query]);

  // 🔹 RICERCA COMPLETA (DB → API)
  const handleSearch = async (q?: string) => {
    const searchQuery = q ?? query;
    if (!searchQuery.trim()) return;

    setLoading(true);
    setError(null);
    setSuggestions([]);

    try {
      const res = await fetch("http://localhost:5000/api/meals/search", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ query: searchQuery }),
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
          className="form-control"
          placeholder="Scrivi una lettera..."
          value={query}
          onChange={(e) => setQuery(e.target.value)}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              handleSearch();
            }
          }}
        />

        {/* SUGGERIMENTI */}
        {suggestions.length > 0 && (
          <ul className="list-group mt-2">
            {suggestions.map((name) => (
              <li
                key={name}
                className="list-group-item list-group-item-action"
                onClick={() => {
                  setQuery(name);
                  handleSearch(name);
                }}
              >
                {name}
              </li>
            ))}
          </ul>
        )}

        {/* BOTTONE */}
        <button
          type="button"
          className="btn btn-success mt-3 mb-4"
          onClick={() => handleSearch()}
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
