"use client";
import Image from "next/image";
import { useState } from "react";
import { InputNumber } from "primereact/inputnumber";
import MouseHandler from "./MouseHandler";
import WheelImage from "./rotellina";
import Cart from "./cart";
import Fox from "./fox";

export default function Home() {
  const [value1, setValue1] = useState<number | null>(null);
  const [value2, setValue2] = useState<number | null>(null);
 

  const result = (value1 ?? 0) + (value2 ?? 0);

  return (
    <div className="flex min-h-screen items-center justify-center bg-zinc-50 font-sans dark:bg-black">
      <main className="flex min-h-screen w-full max-w-3xl flex-col items-center justify-between py-32 px-16 bg-white dark:bg-white sm:items-start">
        <div className="flex flex-col gap-4">
          {/* deve fare la somma tra value1 e value 2 e mostrare il risultato in value3 */}
          <InputNumber
            value={value1}
            onValueChange={(e) => setValue1(e.value ?? null)}
            useGrouping={false}
            placeholder="Value 1"
          />
          <InputNumber
            value={value2}
            onValueChange={(e) => setValue2(e.value ?? null)}
            useGrouping={false}
            placeholder="Value 2"
          />
          <InputNumber
            value={result}
            readOnly
            useGrouping={false}
            placeholder="Result"
          />
        </div>
        
      <MouseHandler />
      <WheelImage />
      <Cart />
      <Fox />
      </main>
    </div>
  );
}
