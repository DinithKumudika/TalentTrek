import { Route, createBrowserRouter, createRoutesFromElements } from 'react-router-dom'

import BaseLayout from './layouts/BaseLayout';

import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';
import JobsPage from './pages/JobsPage';
import JobPage from './pages/JobPage';
import AddJobPage from './pages/AddJobPage';

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
}

export const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path='/' element={<BaseLayout />} errorElement={<NotFoundPage />}>
            <Route index element={<HomePage />} />
            <Route path='/jobs' element={<JobsPage />} />
            <Route path='/jobs/:id' element={<JobPage deleteJob={deleteJob} />} loader={JobPage.loader} />
            <Route path='/jobs/add' element={<AddJobPage addJobSubmit={addJob} />} />
        </Route>
    ),
);

