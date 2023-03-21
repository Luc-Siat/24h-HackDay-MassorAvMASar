import React, { FC } from 'react'
import { IUser } from '../../services/types'

type ContactMeFormProps = {
  user: IUser
}

export const ContactMeForm: FC<ContactMeFormProps> = ({ user }) => {
  return (
    <form className="form" action={`https://formsubmit.co/${user.email}`} method="POST">
    <div className='form-container '>
        <h3 className="form__title">Contact my owner!</h3>

        <input className="w-100 round-corner" placeholder="  Your Email address" name="email" id="email" type="textbox" required/>



        <textarea className="w-100 text-box" placeholder="  Write a bit about you"  name="text" id="text" cols={45} rows={8}/>


        <button className="form-btn btn--blue round-corner" id="">Get in touch <i className="fa-solid fa-paper-plane"></i></button>
    </div>
</form>
  )
}
