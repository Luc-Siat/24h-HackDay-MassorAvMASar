import React, { FC, useEffect, useState } from "react";
import { Navigate, useParams } from "react-router-dom";
import { IDog, ISport, IUser } from "../../services/types";
import { ContactMeForm } from "./ContactMeForm";
import './DogDetailsPage.css'

type DogPageProps = {
  dogs: IDog[],
  users: IUser[],
  sports: ISport[],
  currentUser?: IUser,
  deleteDog: Function
}

export const DogDetailsPage :FC<DogPageProps> = ({ dogs, users, sports, currentUser, deleteDog }) => {

 
  const [dog, setDog] = useState<IDog>();
  const [user, setUser] = useState<IUser>(); 
  const { id }  = useParams();
  const [contactToggle, setContactToggle] = useState<boolean>(false);
  const [redirect, setRedirect] = useState<boolean>(false);

  const toggleContact = () => {
    setContactToggle(!contactToggle);
  
  }
  
  useEffect(() => {
    if (!contactToggle){
      window.scrollTo(0, 0);
    }
    const dog = dogs.find(dog => dog.dogId === +id!);
    setUser(users.find(user => user.userId === dog?.userId));
    setDog(dog);
  }, [])

  if (redirect) {return <Navigate replace to='/Dogs' />}
  
  return (
    <>
      <header className="dog-details__header">
        {dog?.imageUrl ? <img className="dog-details__header-picture" src={dog.imageUrl} alt="picture of the dog" /> : null}
        {currentUser === user && (<button onClick={() => {
          deleteDog(dog?.dogId)
          setRedirect(true)
          
          }} className="delete-dog-btn">Delete your dog profile</button>)} 
        <h2>Hi I'm {dog?.name} 👋</h2>
      </header>
      <main className="container dog-details-main">
          <ul className="dog-details__info">
            <li className="dog-details__info-circle"><i className="fa-solid fa-medal"></i><br/>{sports.find(sport => sport.sportId === dog?.sportId)?.name}</li>
            <li className="dog-details__info-circle"><i className="fa-solid fa-house"></i><br/>{dog?.location}</li>
            <li className="dog-details__info-circle"><i className="fa-solid fa-cake-candles"></i> <br/> {dog?.age} year{dog?.age! > 1 ? 's' : ''} old</li>
          </ul>
            <article className="dog-details__content">
              <div className="dog-details__description">
                <h2>About</h2>
                  <p> Hi 👋 I am mostly looking for people close to {dog?.location} to practice and learn about {sports.find(sport => sport.sportId === dog?.sportId)?.name} </p>
              </div>
              <div className="dog-details__user ">
                <i className="fa-solid fa-dog"></i>
                <p>{dog?.race}</p>
                <i className="fa-solid fa-venus-mars"></i>
                <p>{dog?.gender}</p>
              </div>
              <div className="dog-details__email " onClick={() => toggleContact()}>
                <i className="fa-regular fa-envelope"></i>
                <p>Contact {user?.username}</p>
              </div>


            </article>
            {contactToggle && (<ContactMeForm user ={user!}/>)}
      </main>
    </>
  );
};
