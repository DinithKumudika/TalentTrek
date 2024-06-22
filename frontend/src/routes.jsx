import { Route, createBrowserRouter, createRoutesFromElements } from 'react-router-dom'

import BaseLayout from './layouts/BaseLayout';

import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';

import SignUpPage from './pages/authentication/SignUpPage';

import JobsPage from './pages/jobs/JobsPage';
import JobPage from './pages/jobs/JobPage';
import AddJobPage from './pages/jobs/AddJobPage';
import EditJobPage from './pages/jobs/EditJobPage';


// create a new job
const addJob = async (newJob) => {
    console.log(newJob);

    // TODO: replace with axios
    const res = await fetch('/api/jobs', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newJob),
    });

    return res.status;
}

//delate job
const deleteJob = async (id) => {
    console.log(id);

    // TODO: replace with axios
    const res = await fetch(`/api/jobs/${id}`, {
        method: 'DELETE'
    });

    return res.status;
}

const updateJob = async (job) => {
    console.log(job);
    // TODO: replace with axios
    const res = await fetch(`/api/jobs/${job.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(job)
    });

    return res.status;
}

const registerUser = async (user) => {
    console.log(user);
    await new Promise((resolve) => setTimeout(resolve, 8000));
}

export const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path='/' errorElement={<NotFoundPage />}>
            <Route index element={<HomePage />} />
            <Route
                path='sign-up'
                element={<SignUpPage registerUser={registerUser} />}
            />
            <Route path='jobs' element={<BaseLayout />}>
                <Route
                    path=''
                    element={<JobsPage />}
                />
                <Route
                    path=':id'
                    element={<JobPage deleteJob={deleteJob} />}
                    loader={JobPage.loader}
                />
                <Route
                    path='add'
                    element={<AddJobPage addJobSubmit={addJob} />}
                />
                <Route
                    path='edit/:id'
                    element={<EditJobPage updateJob={updateJob} />}
                    loader={JobPage.loader}
                />
            </Route>
        </Route>
    ),
);

