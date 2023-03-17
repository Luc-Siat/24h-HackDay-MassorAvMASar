import React, { FC } from 'react'
import { Link } from 'react-router-dom'
import './FilterBar.css'

type FilterbarProps = {
  toggleForm: Function,
  toggleSport: Function,
  toggleBreed: Function,
  toggleLocation: Function,
}

export const FilterBar :FC<FilterbarProps> = ({ toggleForm, toggleSport, toggleBreed, toggleLocation }) => {
  return (
    <div className="container filter-bar">
      <button className="filter-box location-filter" onClick={() => toggleLocation()}><h3>Search by location</h3></button>
      <button className="filter-box races-filter" onClick={() => toggleBreed()}><h3>Search by breed</h3></button>
      <button className="filter-box add-dog" onClick={() => toggleForm()}><h3>Add your dog</h3></button>
      <button className="filter-box sport-filter" onClick={() => toggleSport()}><h3>Search by Sport</h3></button>
    </div>
  )
}
