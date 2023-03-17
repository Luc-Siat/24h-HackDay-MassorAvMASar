import React, { FC } from 'react'
import './DogCard.css'
import { IDog, ISport, IUser } from '../../services/types'
import { getSports } from '../../services/MassorAvMasarApi'
import { Link } from 'react-router-dom'

type DogCardProps = {
  dog : IDog,
  user? : IUser,
  sport? : ISport,
}




export const Dogcard :FC<DogCardProps> = ({ dog, user, sport}) => {

  return (
    <Link to={`/Dogs/${dog.dogId}`} className='dog-card'>
      <img className='dog-card__image'src={dog.imageUrl} alt="dog image" />
      <ul className='dog-card__content'>
        <li>{dog.name}</li>
        <li>{dog.location}</li>
        <li>{sport?.name}</li>
      </ul>
    </Link>
  )
}
