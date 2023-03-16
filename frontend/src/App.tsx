import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import './App.css'
import { Navbar } from './components/Navbar'
import { Footer } from './components/Footer'
import { Header } from './components/Header'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Home } from './components/Home'
import { Dogcard } from './components/Dogcard'
import { DogPage } from './components/DogPage'
import { About } from './components/About'
import { Dog } from './services/types'

function App() {
  const [Dogs, setDogs] = useState<Dog[]>();

  useEffect(() => {

  }, [])

  return (
    <div className="App">
      <Navbar />
      <BrowserRouter>
      <Routes>
        <Route path="/Dogs" element={<Home />}/> 
        <Route path="/Dog/:id" element={<DogPage />} />
        <Route path="/About" element={<About />} />
      </Routes>
    </BrowserRouter>
      <Footer /> 
    </div>
  )
}

export default App
