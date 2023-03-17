import { FC, useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import './Navbar.css'

type NavbarProps = {
  loggedIn : boolean,
  logOut: Function
}

export const Navbar : FC<NavbarProps> = ({ loggedIn, logOut }) => {

  return (
    <nav className='navbar'>
      <div className='navbar__container container'>
        <Link to="/">
          <img className='navbar__logo' src="../public/logo.png" alt="logo of mas" />
        </Link>
        
        {loggedIn ? <Link to="/" onClick={() => logOut()}><p>log out</p></Link> : <Link to="/login"><p>login | sign up</p></Link>} 
       
      </div>
    </nav>
  )
}
