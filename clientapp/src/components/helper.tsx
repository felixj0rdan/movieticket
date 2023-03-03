import axios from "axios"

const URL = "https://localhost:7070/";

interface CompHelperProps {
        availaibleTickets: number
        description:string
        duration:number
        genre:string
        id:string
        imageURL:string 
        name:string
        rating:number
}

// export const EditMovie = async (data: CompHelperProps) => {
//     let token = localStorage.getItem("access_token")
//     let response = await axios.put(`${URL}movie/add`, data, {headers: {
//         Authorization: token
//     }})
//     return response.data;
// }

export const AddMovie = async (data: CompHelperProps) => {
    let token = localStorage.getItem("access_token")
    console.log(token);
    
    let response = await axios.post(`${URL}movie/add`, data, {headers: {
        Authorization: `Bearer ${token}`
    }})
    return response.data;
}