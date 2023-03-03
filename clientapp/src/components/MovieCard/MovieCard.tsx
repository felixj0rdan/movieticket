import React, { Dispatch } from 'react'
import styled from 'styled-components'
import { clock, deleteIcon, edit, star, tickets } from '../../assets'

interface MovieCardProps{
   movie: {
    availaibleTickets: number
    description:string
    duration:number
    genre:string
    id:string
    imageURL:string 
    name:string
    rating:number
   },
   setMovie: Dispatch<React.SetStateAction<{
    availaibleTickets: number;
    description: string;
    duration: number;
    genre: string;
    id: string;
    imageURL: string;
    name: string;
    rating: number;
}>>,
admin: boolean,
setAdd: Dispatch<React.SetStateAction<boolean>>
}

const Card = styled.div<{imgUrl:string}>`
    display: flex;
    flex-direction: column;
    flex: -3 0 21%;
    /* border: 1px solid grey; */
    border-radius: 5px;
    justify-content: end;
    /* padding-bottom: 10px; */
    height: 300px;
    /* width: fit-content; */
    width: 200px;
    position: relative;
    background-image: url(${(props) => props.imgUrl});
    background-size: cover;
`

const InfoGradDiv = styled.div`
    height: 100px;
    background-color: white;
    border: 0px;
    display: flex;
    flex-direction: column;
    justify-content: end;
    background: linear-gradient(0deg, rgba(0,0,0,1) 0%, rgba(255,255,255,0) 100%);
`

const InfoDiv = styled.div`
    /* height: 30px; */
    background-color: black;
    border: 0px;
    display: flex;
    /* margin-bottom: 10px; */
    border-bottom-right-radius: 4px;
    border-bottom-left-radius: 4px;
`

const Options = styled.div`
    position: absolute;
    top: 0;
    right: 0;
    display: flex;
    flex-direction: row;
    gap: 10px;
    margin: 10px;
`

const Title = styled.p`
    color: white;
    /* padding: 0px; */
    margin: 0px;
    /* padding-left: 10px;
    padding-bottom: 10px; */
    margin-left: 10px;
    margin-bottom: 5px;
    font-size: large;
`

const Rating = styled.p`
    color: white;
    /* padding: 0px; */
    margin: 0px;
    /* margin-bottom: 10px; */
    margin-left: 10px;
    /* font-size: small; */

    /* padding-left: 10px; */
    margin-bottom: 10px;
    /* margin-top: 10px; */
`


const MovieCard = ({movie, setMovie, admin, setAdd} : MovieCardProps) => {


  return (
    <Card onClick={() => {document.getElementById("card")?.click(); setMovie(movie)}} imgUrl={movie.imageURL} >
        <button id="card" data-toggle="modal" data-target="#details" hidden />



            
        {/* <RatingStar imgUrl={star} /> */}
        {admin && <Options>
                <div onClick={(e) =>{ e.stopPropagation(); document.getElementById("delete-btn")?.click(); setMovie(movie);}}  >
                    <img src={deleteIcon} height="35px" alt="" />
                </div>
                <div onClick={(e) =>{ e.stopPropagation(); document.getElementById("addmovie")?.click(); setMovie(movie); setAdd(false)}}  style={{paddingTop: "3px"}}>
                    <img src={edit} height="30px" alt="" />
                </div>
        </Options>}

        
        
        <InfoGradDiv>
        <Title>{movie.name}</Title>

        </InfoGradDiv>
        <InfoDiv>
                
            <Rating> <span><img src={clock} height="14px" alt="" /></span> {movie.duration}</Rating>
            <Rating> <span><img src={star} height="17px" alt="" /></span> {movie.rating}</Rating>
            <Rating> <span><img src={tickets} height="15px" alt="" /></span> {movie.availaibleTickets}</Rating>



        </InfoDiv>
    </Card>
  )
}

export default MovieCard