import { useState } from "react";

type CartItem = {
  id: number;
  name: string;
  price: number;
};

export default function Cart() {
  const [cart, setCart] = useState<CartItem[]>([]);

  const addItem = (item: CartItem) => {
    setCart((prev) => [...prev, item]);
  };

  return (

    <>
    <p>
        
    </p>
    </>

  ); 
}
