import axios from "axios"

const URL = "https://localhost:7070/";

export const GetAllMovies = () => {
    let response = axios.get(`${URL}movie/get-all`);
    return response;
}

export const LoginAdmin = async (loginData: {username: string, password: string}) => {
    let response = await axios.post(`${URL}admin/login`, loginData);
    return response.data;
}