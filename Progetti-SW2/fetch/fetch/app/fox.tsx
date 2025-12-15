"use client";
/**
 * 
 * 
 * {
  "image": "https://randomfox.ca/images/44.jpg",
  "link": "https://randomfox.ca/?i=44"
}
 */


import { useEffect, useState } from "react";


export default function Dog(){

    const [dog , setDog] = useState({})  // Fox myFox = new Fox();
    const [loading, setLoading] = useState(true);
    const [image , setImage] = useState(" ")

    useEffect(() => {
        let mounted = true;
        fetch('https://random.dog/woof.json')
        .then(res => res.json())
        .then(data => {
            if (mounted) {
                setDog(data);
                setImage(data.url)
                setLoading(false);
            }
        })
        .catch(() => {
            if (mounted) setLoading(false);
        });
        return () => { mounted = false; }; // evita setState dopo unmount
  }, []); // esegue solo al mount


    
    return(
        <>
            <h1>Show some result</h1>

            <img src="https://random.dog/597a7bac-c3ef-41df-be42-9e5bf9188696.jpg" ></img>
            <p>{"https://random.dog/597a7bac-c3ef-41df-be42-9e5bf9188696.jpg}"}</p>
            <pre>{(JSON.stringify(dog, null, 2))}</pre>

        </>
    )
}

/***
 * 
 * 
 * 
 * 
 * import React, { useState, useEffect } from 'react';

function UsersList() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    let mounted = true;
    fetch('https://api.example.com/users')
      .then(res => res.json())
      .then(data => {
        if (mounted) {
          setUsers(data);
          setLoading(false);
        }
      })
      .catch(() => {
        if (mounted) setLoading(false);
      });
    return () => { mounted = false; }; // evita setState dopo unmount
  }, []); // esegue solo al mount

  if (loading) return <div>Loading...</div>;
  return <ul>{users.map(u => <li key={u.id}>{u.name}</li>)}</ul>;
}
 * 
 * 
 * 
 * 
 */