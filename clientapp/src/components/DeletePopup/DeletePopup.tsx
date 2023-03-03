import React from 'react'
import styled from 'styled-components'

const Title = styled.p`
    color: white;
    margin: 0px;
    padding: 0px;
`
interface DeletePopupProps {
    movie: {
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

const DeletePopup = ({movie} : DeletePopupProps) => {
  return (
    <div className="modal-dialog modal-dialog-centered" style={{border: 0}}  role="document">
                        <div className="modal-content">
                            <div className="modal-header" style={{backgroundColor: "#D2042D", borderTopLeftRadius: 2, borderTopRightRadius: 2}} >
                                <Title>Delete Movie</Title>
                            </div>
                            <div className="modal-body">
                                Do you want to delete the movie "{movie.name}"?
                            </div>   
                            <div className="modal-footer">
                                <button onClick={() => null} data-dismiss="modal" style={{backgroundColor: "#D2042D", color: "white"}} type="button"  className="btn">No</button>
                                <button onClick={() => null} data-dismiss="modal" style={{backgroundColor: "#D2042D", color: "white"}} type="button"  className="btn">Yes</button>

                            </div>
                        </div>
                    </div>
  )
}

export default DeletePopup