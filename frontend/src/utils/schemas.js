import * as yup from "yup"

const signUpSchema = yup.object({
    firstName: yup
        .string()
        .required("first name is required"),
    lastName: yup
        .string()
        .required("last name is required"),
    email: yup
        .string()
        .email()
        .required("email is required"),
    password: yup
        .string()
        .required("password is required")
        .min(8, "must have at least 8 characters")
        .max(30, "must be less than 30 characters"),
    confirmPassword: yup
        .string()
        .required("confirm password is required")
        .oneOf([yup.ref("password"), null], "passwords must match")
}).required();

export {signUpSchema};