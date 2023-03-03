import React, { Dispatch } from 'react'
import { useNavigate } from 'react-router-dom';
import styled from "styled-components";
// import {MovieForm} from '../components';
import MovieForm from '../MovieForm/MovieForm';

interface NavbarProps {
    admin: boolean,
    setReload: Dispatch<React.SetStateAction<boolean>>,
setAdd: Dispatch<React.SetStateAction<boolean>>

}

const Nav = styled.div`
    height: 70px;
    background-color: #D2042D;
    display: flex;
    justify-content: space-between;
    
    padding-left: 10px;
    padding-right: 10px;

`

const Title = styled.p`
    margin: 0px;
    color: #f5f5f5;
    /* margin-top: 0px; */

    font-size: 40px;
    font-weight: 200;
    
`

const AdminLoginBtn = styled.button`
    height: 40px;
    margin-top: 15px;
    /* transform: translate(); */
    outline: none;
    background-color: #f5f5f5;
    border-radius: 5px;
    border: 1px solid #f5f5f5;
    /* color: #D2042D; */
    &:hover{
        background-color: #D2042D;
        /* border: 1px solid #f5f5f5; */
        color: #f5f5f5;

    }
    &:focus{
    outline: none;
    }
`

const ControlDiv = styled.div`
    display: flex;
    flex-direction: row;
    /* font-size: medium; */
    gap: 20px;
`
const NavBtn = styled.div`
    height: 41px;
    margin-top: 15px;
    text-align: center;
    padding: 5px;
    padding-top: 7px;
    font-size: medium;
    color: white;
    border: 1px solid #D2042D;
    border-radius: 5px;

    &:hover{
        border: 1px solid white;
        /* color: #fff;
        text-shadow:
            0 0 7px #fff,
            0 0 10px #fff,
            0 0 21px #fff,
            0 0 42px #0fa,
            0 0 82px #0fa,
            0 0 92px #0fa,
            0 0 102px #0fa,
            0 0 151px #0fa; */
            }
`

const NavBar = ({admin, setReload, setAdd}: NavbarProps) => {

    const navigate = useNavigate();

    const toLogin = () => {
        navigate('/admin-login')
    }

    

    const toLogout = () => {
        // navigate('/admin-login')
        localStorage.removeItem("access_token")
        setReload(r => !r)
    }

    return (
        <>
        <Nav>
            <Title>Tickets</Title>
            <ControlDiv>
                
                {admin && <NavBtn onClick={() => {document.getElementById("addmovie")?.click(); setAdd(true)}} ><p>Add Movie</p></NavBtn> }
                <button id="addmovie" data-toggle="modal" data-target="#addMovieModel" data-dismiss="modal" hidden >click</button>

                <AdminLoginBtn onClick={admin?toLogout:toLogin} >{admin ? "Logout" : "Admin Login"}</AdminLoginBtn>
            </ControlDiv>
        </Nav>
        
        </>
    )
}

export default NavBar