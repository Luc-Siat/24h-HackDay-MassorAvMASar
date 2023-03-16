import React from 'react'
import { Dogcard } from './Dogcard'
import { FilterBar } from './FilterBar'
import { Header } from './Header'

export const Home = () => {
  return (
    <>
    <Header />
    <FilterBar />
    <Dogcard />
    <Dogcard />
    </>
  )
}
