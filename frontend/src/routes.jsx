import { Route, createBrowserRouter, createRoutesFromElements } from 'react-router-dom'

import BaseLayout from './layouts/BaseLayout';

import HomePage from './pages/HomePage';
import JobsPage from './pages/JobsPage';
import NotFoundPage from './pages/NotFoundPage';
import JobPage from './pages/JobPage';

export const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path='/' element={<BaseLayout />} errorElement={<NotFoundPage/>}>
            <Route index element={<HomePage />} />
            <Route path='/jobs' element={<JobsPage />} />
            <Route path='/jobs/:id' element={<JobPage/>} loader={JobPage.loader} />
        </Route>
    ),
);

