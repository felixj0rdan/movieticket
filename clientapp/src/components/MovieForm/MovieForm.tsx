import React, { Dispatch, useEffect, useState } from 'react'
import styled from 'styled-components'
import { AddMovie } from '../helper'

interface MovieFormProps {
    add:boolean,
    setReload: Dispatch<React.SetStateAction<boolean>>,
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
    }>>
}

const Title = styled.p`
    color: white;
    margin: 0px;
    padding: 0px;
`

const Input = styled.input<{width:string}>`
    width: ${props => props.width};

    ::-webkit-inner-spin-button{
        -webkit-appearance: none; 
        margin: 0; 
    }
    ::-webkit-outer-spin-button{
        -webkit-appearance: none; 
        margin: 0; 
    }    
`;

const MovieForm = ({add, setMovie, movie, setReload}: MovieFormProps) => {

    const [formData, setFormData] = useState({
        availaibleTickets: 0,
        description: "",
        duration: 0,
        genre: "",
        id: "",
        imageURL: "",
        name: "",
        rating: 0,
    })

    useEffect(() => {
      if(add){
        setFormData({
            availaibleTickets: 0,
            description: "",
            duration: 0,
            genre: "",
            id: "",
            imageURL: "",
            name: "",
            rating: 0,
        })
        console.log("check");
      } else{
        setFormData(movie);
      }
    }, [add])
    console.log(formData)


    const updateValue = (key: string, value: any) => {
        // var tempData = formData;
        // tempData[key] = value;
        setFormData({...formData, [key]:value})

    }

    const onSubmit = () => {
        if(add){
            AddMovie(formData)
            .then(res => {console.log(res); setReload(r => !r)})
            setFormData({
                availaibleTickets: 0,
                description: "",
                duration: 0,
                genre: "",
                id: "",
                imageURL: "",
                name: "",
                rating: 0,
            })
        } else {

        }
    }
    

  return (
                    <div className="modal-dialog modal-dialog-centered" style={{border: 0}}  role="document">
                        <div className="modal-content">
                            <div className="modal-header" style={{backgroundColor: "#D2042D", borderTopLeftRadius: 2, borderTopRightRadius: 2}} >
                                <Title>{add ? "Add Movie" : "Edit Movie"}</Title>
                            </div>
                            <div className="modal-body">
                                <div className="form-group">
                                    <label >Title</label>
                                    <Input value={formData.name} width={"100%"}  onChange={(e) => updateValue("name", e.target.value)} className="form-control"  placeholder=""/>                        
                                </div>
                                <div className="form-group">
                                    <label >Genre</label>
                                    <Input value={formData.genre} width={"100%"}   onChange={(e) => updateValue("genre", e.target.value)} className="form-control"  placeholder=""/>                        
                                </div>
                                <div className="form-group" style={{display: "flex", gap: "50px"}}>
                                    <label >Duration
                                    <Input value={formData.duration} width={"120px"}  type="number" onChange={(e) => updateValue("duration", e.target.value)} className="form-control"  placeholder=""/>  </label>
                                    <label >Rating
                                    <Input value={formData.rating} width={"120px"}  type="number"  onChange={(e) => updateValue("rating", e.target.value)} className="form-control"  placeholder=""/>    </label>                    
                                    <label >Tickets Avaliable
                                    <Input value={formData.availaibleTickets} width={"120px"}  type="number"  onChange={(e) => updateValue("availaibleTickets", e.target.value)} className="form-control"  placeholder=""/>                        
                                    </label>
                                </div>
                                
                                <div className="form-group">
                                <label >Image URL</label>
                                    <Input value={formData.imageURL} width={"300px"}  type="text"  onChange={(e) => updateValue("imageURL", e.target.value)} className="form-control"  placeholder=""/>                        
                                    
                                </div>
                                
                                <div className="form-group">
                                    <label >Description</label>
                                    <textarea value={formData.description} onChange={(e) => updateValue("description", e.target.value)} className="form-control" rows={2}></textarea>
                                </div>
                            </div>   
                            <div className="modal-footer">
                                <button onClick={onSubmit} data-dismiss="modal" style={{backgroundColor: "#D2042D", color: "white"}} type="button"  className="btn">{add?"Add":"Edit"}</button>
                            </div>
                        </div>
                    </div>

  )
}

export default MovieForm