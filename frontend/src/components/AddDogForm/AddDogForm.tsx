import React, { FC, SyntheticEvent, useEffect, useState } from 'react'
import { IDog, ISport } from '../../services/types'
import './AddDogForm.css'

type AddDogFormProps = {
    sports: ISport[]
    submitDog: Function
}

export const AddDogForm :FC<AddDogFormProps> = ({sports, submitDog}) => {
    const [name, setName] = useState('');
    const [gender, setGender] = useState('Female');
    const [age, setAge] = useState(0);
    const [location, setLocation] = useState('');
    const [breed, setBreed] = useState('');
    const [sportId, setSportId] = useState<number>();
    const [imageUrl, setImageUrl] = useState('');
    const [description, setDescription] = useState('');

    const createDog = (e : SyntheticEvent) => {
        e.preventDefault();
        const dog : Partial<IDog> =  {name: name, gender: gender, age: age, location: location, race: breed, sportId: sportId, imageUrl: imageUrl, description: description}
        submitDog(dog);
    }

    // useEffect(() = {
 
    // }, [])

  return (
    <form className="form" onSubmit={ (e) => createDog(e)}>
        <div className='container form-container'>

            <h3 className="add-dog-form__title">Join the fun and add your dog!</h3>

            <div className="w-100">
            <input className="round-corner" placeholder="  Name" id="name" type="text" required onChange={e => { setName(e.target.value); }}/>
            </div>   

            <input className="w-100 round-corner" placeholder="  Image url"  id="imageUrl" type="text" onChange={e => { setImageUrl(e.target.value); }}/>

            <select className="w-100 round-corner" placeholder="  Gender" id="gender" onChange={e => { setGender(e.target.value); }}>
                <option value="Female">Female</option>
                <option value="Male">Male</option>
            </select>

            <textarea className="w-100 text-box" placeholder="  Write a bit about you"  id="text" cols={45} rows={8} onChange={e => { setDescription(e.target.value); }}/>

            <input className="w-100 round-corner " placeholder="  Age" id="age" type="text" onChange={e => { setAge(+(e.target.value)); }}/>

            <input className="w-100 round-corner " placeholder=" Location" id="location" type="text" onChange={e => { setLocation(e.target.value); }}/>

            <input className="w-100 round-corner " placeholder="  Breed" id="breed" type="text" onChange={e => { setBreed(e.target.value); }}/>

            <select className="w-100 round-corner" placeholder="  Sport" name="sportId" id="sportId" onChange={e => setSportId(+(e.target.value))}>
            <option value="">Favorite dog sport</option>
            {sports.map(sport => <option key={sport.sportId} value={sport.sportId}>{sport.name}</option> )}
            </select>

            <button className="form-btn btn--blue round-corner" id="">Add your dog</button>
        </div>
    </form>
  )
}
