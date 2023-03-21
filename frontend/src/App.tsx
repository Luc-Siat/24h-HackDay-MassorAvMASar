import { createContext, SyntheticEvent, useContext, useEffect, useState } from 'react'
import React from 'react'
import reactLogo from './assets/react.svg'
import './App.css'
import { Navbar } from './components/App/Navbar/Navbar'
import { Footer } from './components/App/Footer/Footer'
import { BrowserRouter, Navigate, redirect, Route, Routes } from 'react-router-dom'
import { Home } from './components/Home/Home'
import { Dogcard } from './components/DogCard/Dogcard'
import { DogDetailsPage } from './components/DogPage/DogDetailsPage'
import { About } from './components/About'
import { IDog, ISport, IUser } from './services/types'
import { addDog, deleteDog, getDogs, getSports, getUsers, IUpdate, updateDog } from './services/MassorAvMasarApi'
import { Login } from './components/login/Login'


function App() {
  const [currentUser, setCurrentUser] = useState<IUser>();
  const [loggedIn, setLoggedIn] = useState<boolean>(false);
  const [users, setUsers] = useState<IUser[]>([]);
  const [sports, setSports] = useState<ISport[]>([]);
  const [dogs, setDogs] = useState<IDog[]>([]);

  const getData = async () => {
    setUsers(await getUsers());
    setSports(await getSports());
    setDogs(await getDogs());
  }
  
  const submitDog = async (dog : IDog) => {
    dog.userId = currentUser!.userId;
    const addedDog = await addDog(dog);
    setDogs([...dogs, addedDog])
  }

  const getCurrentUser = (user: IUser) => {
    setCurrentUser(user);
    setLoggedIn(true)
  }

  const logOut = () => {
    setCurrentUser(undefined);
    setLoggedIn(false);
  }

    const deleteDogRequest = async (id :number) => {
      const deleteRequest = await deleteDog(id);
      setDogs(dogs.filter(dog => dog.dogId !== id))
  }

    const UpdateDogRequest = async (id:number, imageUrl :string) => {
      const urlRequest : IUpdate = { imageUrl :imageUrl}
      const updateRequest = await updateDog(id, urlRequest);
      const updatedDog = dogs.find(dog => dog.dogId === id);
      updatedDog!.imageUrl = imageUrl;
      const updatedDogs =  dogs.filter(dog => dog.dogId !== id)
      updatedDogs!.push(updatedDog!);
      setDogs(updatedDogs);
    }

    useEffect( () => {
      getData();
    }, [])
  
  return (
      <div className="App">
        <BrowserRouter>
         <Navbar loggedIn={currentUser != undefined} logOut={logOut}/>
        <Routes>
          <Route path="/" element={< Navigate to='/Dogs' />}/> 
          <Route path="/Dogs" element={<Home dogs={dogs} users={users} sports={sports} submitDog={submitDog} currentUser={currentUser} loggedIn={loggedIn} />}/>
          <Route path="/Dogs/:id" element={<DogDetailsPage dogs={dogs} users= {users} sports={sports} updateDog={UpdateDogRequest}       currentUser= {currentUser} 
          deleteDog ={deleteDogRequest}/>} />
          <Route path="/About" element={<About />} />
          <Route path="/Login" element={<Login getCurrentUser = {getCurrentUser} users={users}/>} />
        </Routes>
        <Footer /> 
      </BrowserRouter>
      </div>
  )
}

export default App
