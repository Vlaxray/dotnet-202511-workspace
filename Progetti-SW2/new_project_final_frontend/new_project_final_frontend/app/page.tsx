"use client";

import { useState, useEffect } from "react";
import { AutoComplete } from "primereact/autocomplete";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { ProgressSpinner } from "primereact/progressspinner";
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
    }, 300);

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

      if (!res.ok) throw new Error();

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
    <div className="min-h-screen flex justify-center items-center bg-gradient-to-br from-green-50 to-orange-50">
      <Card
        title="🍝 Cerca un piatto"
        subTitle="Ingredienti, tradizioni e sapori"
        className="w-full max-w-3xl shadow-4"
      >
        <div className="flex flex-col gap-3">
          
          {/* AUTOCOMPLETE */}
          <AutoComplete
            value={query}
            suggestions={suggestions}
            completeMethod={() => {}}
            onChange={(e) => setQuery(e.value)}
            onSelect={(e) => handleSearch(e.value)}
            placeholder="Scrivi una lettera..."
            className="w-full"
            inputClassName="w-full"
          />

          {/* BOTTONE */}
          <Button
            label="Cerca"
            icon="pi pi-search"
            className="p-button-success"
            onClick={() => handleSearch()}
          />

          {/* LOADING */}
          {loading && (
            <div className="flex justify-center mt-4">
              <ProgressSpinner style={{ width: "40px", height: "40px" }} />
            </div>
          )}

          {/* ERRORE */}
          {error && (
            <p className="text-red-600 text-center mt-2">{error}</p>
          )}

          {/* RISULTATO */}
          {meal && (
            <div className="mt-4">
              <Prodotti meal={meal} />
            </div>
          )}
        </div>
      </Card>
    </div>
  );
}
