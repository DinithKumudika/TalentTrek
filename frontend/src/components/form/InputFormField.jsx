import { useState } from "react";

const InputFormField = ({type, label, id, name}) => {
    const [value, setValue] = useState('');

    return (
        <div className="mb-4">
            <label className="block text-gray-700 font-bold mb-2"
            >{label}</label>
            <input
                type={type}
                id={id}
                name={name}
                className="border rounded w-full py-2 px-3 mb-2"
                placeholder="eg. Beautiful Apartment In Miami"
                required
                value={value}
                onChange={(e) => setValue(e.target.value)}
            />
        </div>
    )
}

export default InputFormField;