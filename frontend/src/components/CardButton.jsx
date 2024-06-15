import { Link } from "react-router-dom"

/* eslint-disable react/prop-types */
const CardButton = ({ link, text, bgColor, bgHoverColor }) => {
     return (
          <Link
               to={link}
               className={`inline-block ${bgColor} text-white rounded-lg px-4 py-2 hover:${bgHoverColor}`}
          >
               {text}
          </Link>
     )
}

export default CardButton