import { useLoaderData, useNavigate, Link } from "react-router-dom";
import { FaArrowLeft, FaMapMarker, FaDollarSign, FaEdit, FaTrash } from 'react-icons/fa';
import { toast } from "react-toastify";

import Spinner from "../../components/Spinner";

const JobPage = ({deleteJob}) => {
    const job = useLoaderData();
    const isLoading = !job;

    const navigate = useNavigate();

    const handleDelete = (jobId) => {
        // TODO: add dialog box to get confirmation
        const status = deleteJob(jobId);
        console.log(status);

        toast.success('Deleted Successfully');
        // TODO: check response status
        return navigate('/jobs');
    }

    return (
        <>
            <section>
                <div className='container m-auto py-6 px-6'>
                    <Link
                        to='/jobs'
                        className='text-indigo-500 hover:text-indigo-600 flex items-center'
                    >
                        <FaArrowLeft className='mr-2' /> Back to Job Listings
                    </Link>
                </div>
            </section>

            {isLoading ? <Spinner /> : (
                <section className='bg-indigo-50'>
                    <div className='container m-auto py-10 px-6'>
                        <div className='grid grid-cols-1 md:grid-cols-70/30 w-full gap-6'>
                            <main>
                                <div className='bg-white p-6 rounded-lg shadow-md text-center md:text-left'>
                                    <div className='text-gray-500 mb-4'>{job.type}</div>
                                    <h1 className='text-3xl font-bold mb-4'>{job.title}</h1>
                                    <div className='text-gray-500 mb-4 flex align-middle justify-center md:justify-start'>
                                        <FaMapMarker className='text-orange-700 mr-1' />
                                        <p className='text-orange-700'>{job.location}</p>
                                    </div>
                                </div>

                                <div className='bg-white p-6 rounded-lg shadow-md mt-6'>
                                    <h3 className='text-indigo-800 text-lg font-bold mb-6'>
                                        Job Description
                                    </h3>

                                    <p className='mb-4'>{job.description}</p>

                                    <h3 className='text-indigo-800 text-lg font-bold mb-2'>
                                        Salary (USD)
                                    </h3>
                                    <FaDollarSign className="text-indigo-800 inline mb-1 mr-1" />
                                    <span className='mb-4'>{job.salary} / Year</span>
                                </div>
                            </main>

                            {/* <!-- Sidebar --> */}
                            <aside>
                                <div className='bg-white p-6 rounded-lg shadow-md'>
                                    <h3 className='text-xl font-bold mb-6'>Company Info</h3>

                                    <h2 className='text-2xl'>{job.company.name}</h2>

                                    <p className='my-2'>{job.company.description}</p>

                                    <hr className='my-4' />

                                    <h3 className='text-xl'>Contact Email:</h3>

                                    <p className='my-2 bg-indigo-100 p-2 font-bold'>
                                        {job.company.contactEmail}
                                    </p>

                                    <h3 className='text-xl'>Contact Phone:</h3>

                                    <p className='my-2 bg-indigo-100 p-2 font-bold'>
                                        {job.company.contactPhone}
                                    </p>
                                </div>

                                <div className='bg-white p-6 rounded-lg shadow-md mt-6'>
                                    <Link
                                        to={`jobs/edit/${job.id}`}
                                        className='bg-indigo-500 hover:bg-indigo-600 text-white text-center font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block'
                                    >
                                        <div className="flex justify-center"><FaEdit className="mt-1"/><span className="ml-2 mt-0.5">Edit</span></div>
                                    </Link>
                                    <button
                                        className='bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block'
                                        onClick={()=> handleDelete(job.id)}
                                    >
                                        <div className="flex justify-center"><FaTrash className="mt-1"/><span className="ml-2 mt-0.5">Delete</span></div>
                                    </button>
                                </div>
                            </aside>
                        </div>
                    </div>
                </section>
            )}
        </>
    )
}

const jobLoader = async ({ params }) => {
    // TODO: replace with axios
    const res = await fetch(`/api/jobs/${params.id}`);
    const data = await res.json();
    return data;
}

JobPage.loader = jobLoader;

export default JobPage;