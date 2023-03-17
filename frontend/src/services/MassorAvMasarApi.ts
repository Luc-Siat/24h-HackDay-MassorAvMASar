// import { DeveloperRequest } from '../components/types';

import { IDog } from "./types";

const DogsUrl = 'https://localhost:3000/api/Dogs';
const SportsUrl = 'https://localhost:3000/api/Sports';
const UsersUrl = 'https://localhost:3000/api/Users';



export const getSports = async () => fetch(SportsUrl, {
  method: 'GET',
  headers: { 'Content-Type': 'application/json' },
})
  .then(response => response.json())
  .then(data => data);

export const getUsers = async () => fetch(UsersUrl, {
  method: 'GET',
  headers: { 'Content-Type': 'application/json' },
})
  .then(response => response.json())
  .then(data => data);

export const getDogs = async () => fetch(DogsUrl, {
  method: 'GET',
  headers: { 'Content-Type': 'application/json' },
})
  .then(response => response.json())
  .then((data : IDog[]) => data);

  export interface IUpdate {
    imageUrl: string
  }

  export const updateDog = async (id: number, url: IUpdate) => {
    const dogToJson = JSON.stringify(url); 
    console.log(dogToJson);
    return fetch(`${DogsUrl}/${id}`, {
      method: 'PUT',
      body: dogToJson,
      headers: { 'Content-Type': 'application/json' },
    })
  };

export const addDog = async (dog : IDog) => {
  const dogToJson = JSON.stringify(dog);
  console.log(dogToJson);
  return fetch(DogsUrl, {
    method: 'POST',
    body: dogToJson,
    headers: { 'Content-Type': 'application/json' },
  })
    .then(response => response.json())
    .then(data => data);
};

export const deleteDog = async (dogId: number) => fetch(`${DogsUrl}/${dogId}`, {
  method: 'DELETE',
  headers: { 'Content-Type': 'application/json' },
});
