import React, { FC, useEffect, useRef, useState } from 'react'
import { IDog, ISport, IUser } from '../../services/types'
import { Dogcard } from '../DogCard/Dogcard'
import { Banner } from '../Banner/Banner'
import { FilterBar } from '../FilterBar/FilterBar'
import './Home.css'
import { AddDogForm } from '../AddDogForm/AddDogForm'
import { TransitionGroup, CSSTransition } from "react-transition-group";
import { addDog, deleteDog } from '../../services/MassorAvMasarApi'

type HomeProps = {
  dogs: IDog[],
  users: IUser[],
  sports: ISport[],
  submitDog: Function,
  currentUser?: IUser,
  loggedIn: boolean

}

export const Home : FC<HomeProps> = ({ dogs, users, sports, submitDog, currentUser,loggedIn }) => {
  const [addFormToggle, setAddFormToggle] = useState<boolean>(false);
  const [sportToggle, setSportToggle] = useState<boolean>(false);
  const [breedToggle, setBreedToggle] = useState<boolean>(false);
  const [locationToggle, setLocationToggle] = useState<boolean>(false);

  const [sportFilter, setSportFilter] = useState<number>(0);
  const [locationFilter, setLocationFilter] = useState<string>("");
  const [breedFilter, setBreedFilter] = useState<string>("");
 


  const [currentPage, setCurrentPage] = useState(1);
  const [currentDogs, setCurrentDogs] = useState<number[]>([0, 10]);
  const backToTop = useRef();
  
  const toggleForm = () => {
    setAddFormToggle(!addFormToggle);
  }
  const toggleSport = () => {
    setSportToggle(!sportToggle);
  }
  const toggleBreed = () => {
    setBreedToggle(!breedToggle);
  }
  const toggleLocation = () => {
    setLocationToggle(!locationToggle);
  }

  const HandleSubmit = (dog : IDog) => {
    submitDog(dog);
    setAddFormToggle(!addFormToggle);
  }

  const filterDogs = (dogs : IDog[]) => {
    return dogs.filter( dog => (sportFilter === 0 || dog.sportId === sportFilter) &&
      (locationFilter === "" || dog.location === locationFilter) &&
      (breedFilter === "" || dog.race === breedFilter))
  }


  const handlePagination = (num : number) => {
    if (num < 1 && currentPage === 1) {
      return;
    }  if ( num === 0 ) {
      setCurrentPage(currentPage - 1);
      setCurrentDogs([(currentDogs[0] -10),(currentDogs[1] -10)])
      backToTop.current.scrollIntoView()
    } if ( num === 1 ) {
      setCurrentPage(currentPage + 1);
      setCurrentDogs([(currentDogs[0] + 10),(currentDogs[1] + 10)])
      backToTop.current.scrollIntoView()
    }
  }

  return (
    <>
    <header>
      <Banner />
      <p className='container header-content'>Looking for the perfect breed match or just a friend for your dog? </p>
    </header>
    <main className='home-main'>
      <FilterBar toggleForm={toggleForm} toggleSport={toggleSport} toggleBreed={toggleBreed} toggleLocation={toggleLocation} />

      {sportToggle && (
        <div className='container'>
         <select className="w-100 round-corner" placeholder="  Sport" name="sportId" id="sportId" onChange={e => setSportFilter(+ e.target.value)}>
         <option value={0}>no sport filter</option>
         {sports.map(sport => <option key={sport.sportId} value={sport.sportId}>{sport.name}</option> )}
         </select>
        </div>
      )}
      {breedToggle && (
        <div className='container'>
         <select className="w-100 round-corner" placeholder="  Breed" name="breedId" id="breed" onChange={e => setBreedFilter(e.target.value)}>
         <option value="">no breed filter</option>
         {dogs.filter((n, i) => dogs.indexOf(n) === i).map(dog => <option key={dog.dogId} value={dog.race}>{dog.race}</option> )}
         </select>
        </div>
      )}
        {locationToggle && (
        <div className='container'>
         <select className="w-100 round-corner" placeholder="  Location" name="locationId" id="location" onChange={e => setLocationFilter(e.target.value)}>
         <option value="">no location filter</option>
         {dogs.map(dog => <option key={dog.dogId} value={dog.location}>{dog.location}</option> )}
         </select>
        </div>
      )}

      <TransitionGroup component={null}>
        {(addFormToggle && loggedIn) && (
          <CSSTransition classNames="form" timeout={200}>
            <AddDogForm sports= {sports} submitDog={HandleSubmit} />
          </CSSTransition>
        )}
        </TransitionGroup>    
          {(addFormToggle && !loggedIn) && (<p className='log-error'>Please log in to add your dog</p>)}
          
      <div className='pagination' ref={backToTop}>
        <button  onClick={()=> handlePagination(0)}>Prev</button>- {currentPage} - <button onClick={()=> handlePagination(1)}>Next</button>
      </div>  
      
      <div className='dog-board container' >
        <h2 className='dog-board__header'>Just joined</h2>
        {filterDogs(dogs).sort((one, two) => (one.dogId > two.dogId ? -1 : 1)).slice(currentDogs[0], currentDogs[1]).map(dog => 
          <Dogcard 
          user= {users.find(user => user.userId === dog.userId)}
          dog={dog} 
          key={dog.dogId}
          sport= {sports.find(sport => sport.sportId === dog.sportId)}
          />   
        )}
      </div>
      <div className='pagination'>
        <button  onClick={()=> handlePagination(0)}>Prev</button>- {currentPage} - <button onClick={()=> handlePagination(1)}>Next</button>
      </div>
    </main>
    </>
  )
}
