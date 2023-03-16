// import { DeveloperRequest } from '../components/types';

const DogsUrl = 'http://localhost:3000/api/Dogs';
const SportsUrl = 'http://localhost:3000/api/Sports';
const UsersUrl = 'http://localhost:3000/api/Users';



// export const getSports = async () => fetch(SportsUrl, {
//   method: 'GET',
//   headers: { 'Content-Type': 'application/json' },
// })
//   .then(response => response.json())
//   .then(data => data.bootcamps);

// export const getInstructors = async () => fetch(UsersUrl, {
//   method: 'GET',
//   headers: { 'Content-Type': 'application/json' },
// })
//   .then(response => response.json())
//   .then(data => data.instructors);

export const getDogs = async () => fetch(DogsUrl, {
  method: 'GET',
  headers: { 'Content-Type': 'application/json' },
})
  .then(response => response.json())
  .then(data => data.dogs);

// export const addDog = async (dog : DogRequest) => {
//   const dogToJson = JSON.stringify(dog);
//   return fetch(DogsUrl, {
//     method: 'POST',
//     body: dogToJson,
//     headers: { 'Content-Type': 'application/json' },
//   })
//     .then(response => response.json())
//     .then(data => data.developer);
// };

// export const deleteDog = async (dogId: string) => fetch(`${DogsUrl}/${dogId}`, {
//   method: 'DELETE',
//   headers: { 'Content-Type': 'application/json' },
// });
