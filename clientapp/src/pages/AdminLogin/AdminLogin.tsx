import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import styled from 'styled-components'
import { hide, show } from '../../assets'
import { NavBar } from '../../components'
import { LoginAdmin } from '../helper'

const MainDiv = styled.div`
  display: flex;
  flex-direction: column;
  width: 30%;
  /* border: 1px solid black; */
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  padding: 30px;
  /* justify-content: center; */
  align-items: center;
  gap: 20px;
  background-color: #f5f5f5;
  border-radius: 10px;
`
const Input = styled.input`
  width: ${props => props.width};
  border: 0px;
  &:focus{
    outline: none;
  }
`
const InputDiv = styled.div`
  display: flex;
  background-color: white;
  padding: 5px;
  padding-right: 8px;

  border-radius: 5px;
`

const Label = styled.p`
  padding: 0px;
  margin: 0px;
  color: #D2042D;
  margin-bottom: 10px;
`

const SubmitBtn = styled.button<{active:boolean}>`
  border: 1px solid #D2042D;
  height: 35px;
  background: none;
  font-size: large;
  /* outline: none; */
  color: ${props => (props.active ? "#f5f5f5" : "#D2042D") };
  width: 150px;
  margin: 10px;
  background-color: ${props => (props.active ? "#D2042D" : "#f5f5f5") };
  border-radius: 20px;
  &:focus{
    outline: none;
  }
`

const PasswordIcon = styled.div`
  height: 10px;
`

const AdminLogin = () => {

  const [showPassword, setShowPassword] = useState(false)
  const [enableBtn, setEnableBtn] = useState(false)
  const navigate = useNavigate();

  const [username, setUsername] = useState("")
  const [password, setPassword] = useState("")

  const [adminLoggedIn, setAdminLoggedIn] = useState(false)
  const [reload, setReload] = useState(false)

  const [add, setAdd] = useState(false)



  useEffect(() => {
    if(localStorage.getItem("access_token") && localStorage.getItem("access_token") != "" ){
      setAdminLoggedIn(true)
  } else {
      setAdminLoggedIn(false)
  }
   if(username != "" && password !== ""){
    setEnableBtn(true);
   } else {
    setEnableBtn(false)
   }

  }, [username, password])
  
  const onLogin = () => {
    LoginAdmin({username: username, password: password})
    .then(data => {
      if(data.token != null || data.token !== "" ){
        localStorage.setItem("access_token", data.token)
        navigate("/")
      }
    })
  }

  return (
    <>
      <NavBar setReload={setReload} setAdd={setAdd} admin={adminLoggedIn} />
      <MainDiv>
        <div>
        <Label>Username</Label>
        <InputDiv>
        <Input onChange={(e) => setUsername(e.target.value)} width={"260px"} type="text" />
        </InputDiv>
        </div>
        <div>
        <Label>Password</Label>
        <InputDiv>
          <Input onChange={(e) => setPassword(e.target.value)} width={"240px"}  type={showPassword? "text" : "password"} /> <PasswordIcon onClick={() => setShowPassword(s => !s)} ><img src={showPassword?hide:show} height="22px" ></img></PasswordIcon>
        </InputDiv>
        </div>        
        <SubmitBtn active={enableBtn} disabled={!enableBtn} onClick={onLogin} >Login</SubmitBtn>
      </MainDiv>
    </>
  )
}

export default AdminLogin