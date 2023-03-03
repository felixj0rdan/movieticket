import React from 'react'

interface MovieDetailsProps {
    movie : {
        availaibleTickets:number
    description:string
    duration:number
    genre:string
    id:string
    imageURL:string
    name:string
    rating:number
    }
}

const MovieDetails = ({movie}:MovieDetailsProps) => {
  return (
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                {movie.name}
                            </div>
                            <div className="modal-body" style={{display: "flex", gap: "10px"}}>
                                
                                    <img src={movie.imageURL} height="250px" alt="" />
                                    <div><p>Genre: {movie.genre}</p>
                                <p>Rating: {movie.rating}</p>
                                <p>Duration: {movie.duration}</p>
                                <p>Description: {movie.description}</p>
                                </div>

                            </div>
                        </div>
                    </div>
                
  )
}

export default MovieDetails