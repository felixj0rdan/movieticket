import React, { useEffect, useState } from 'react'
import styled from 'styled-components'
import { DeletePopup, MovieCard, MovieDetails, MovieForm, NavBar } from '../../components'
import { GetAllMovies } from '../helper'
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

const MoviesMain = styled.div`
    display: flex;
    flex-wrap: wrap;
    gap: 30px;
    padding: 2%;
    /* align-items: center; */
`
const Landing = () => {

    const [movie, setMovie] = useState({
        availaibleTickets:0,
        description:"",
        duration:0,
        genre:"",
        id:"",
        imageURL:"",
        name:"",
        rating:0,
    })
    const [formMovie, setFormMovie] = useState({
        availaibleTickets:0,
        description:"",
        duration:0,
        genre:"",
        id:"",
        imageURL:"",
        name:"",
        rating:0,
    })
    const [movies, setMovies] = useState([])
    const [show, setShow] = useState(false)
    const [adminLoggedIn, setAdminLoggedIn] = useState(false)
    const [reload, setReload] = useState(false)
    const [add, setAdd] = useState(true)

    useEffect(() => {
        if(localStorage.getItem("access_token") && localStorage.getItem("access_token") != "" ){
            setAdminLoggedIn(true)
        } else {
            setAdminLoggedIn(false)
        }
        GetAllMovies()
        .then(data => setMovies(data.data))
    }, [reload])

    console.log(movies);
    


    return (
        <>
            <NavBar setReload={setReload} setAdd={setAdd} admin={adminLoggedIn}/>            
             <div className="modal fade" id="details" tabIndex={-1} role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <MovieDetails movie={movie} />
            </div>
            <div className="modal fade"   id="addMovieModel" tabIndex={-1} role="dialog" >
            <MovieForm setReload={setReload} setMovie={setMovie} add={add} movie={movie} />
        </div>
            <div className="modal fade" id="delete" tabIndex={-1} role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
                {/* <MovieDetails movie={movie} /> */}
                <DeletePopup movie={movie} />
        <button id="delete-btn" data-toggle="modal" data-target="#delete"  hidden />

            </div>
            <MoviesMain>
                {
                    movies.map((movie, index) => <MovieCard key={index} admin={adminLoggedIn} setAdd={setAdd} movie={movie} setMovie={setMovie}  />)
                }
            </MoviesMain>
        </>
        
    )
}

export default Landing