import React, { FC, SyntheticEvent, useState} from 'react'
import { Navigate, redirect } from 'react-router-dom';
import { IUser } from '../../services/types';
import './login.css'

type LoginProps = {
    getCurrentUser: Function,
    users: IUser[]
}

export const Login: FC<LoginProps> = ({ getCurrentUser, users }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [toggleErrorMessage, setToggleErrorMessage] = useState<boolean>(false);
    const [redirect, setRedirect] = useState<boolean>(false);

    const HandleSubmit = (e : SyntheticEvent) => {
        e.preventDefault()
        var user = users.find(user => user.username === username && user.password === password)
        if ( user == null)
        {
            setToggleErrorMessage(true);
        }
        setToggleErrorMessage(false);
        setRedirect(true);
        getCurrentUser (user);

    }

    if (redirect) {return <Navigate replace to='/Dogs' />}

  return (
    <form className="form login-form" onSubmit={ (e) => HandleSubmit(e)}>
    <div className='form-container '>

        <h3 className="form__title">Login</h3>

        <input className="w-100 round-corner" placeholder="  Username"  id="email" type="textbox" required onChange={(e) => setUsername(e.target.value)}/>

        
        <input className="w-100 round-corner" placeholder="  Password"  id="email" type="textbox" required onChange={(e) => setPassword(e.target.value)}/>

        {toggleErrorMessage && (<p className='log-error'>Invalid credentials, try again</p>)}


        <button className="form-btn btn--blue round-corner" id="">Submit <i className="fa-solid fa-paper-plane"></i></button>
    </div>
</form>
  )
}
