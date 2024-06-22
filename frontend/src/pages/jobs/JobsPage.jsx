import JobListings from "../../components/JobListings"

const JobsPage = () => {
  return (
    <>
      <section style={{height: 'calc(100vh - 6rem)'}} className="bg-blue-50 px-4 py-6">
        <JobListings />
      </section>
    </>
  )
}

export default JobsPage;