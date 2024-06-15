import Card from "./Card"
import CardButton from "./CardButton"

const HomeCards = () => {
     return (
          <section className="py-4">
               <div className="container-xl lg:container m-auto">
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4 p-4 rounded-lg">
                         <Card>
                              <h2 className="text-2xl font-bold">For Developers</h2>
                              <p className="mt-2 mb-4">
                                   Browse our React jobs and start your career today
                              </p>
                              <CardButton 
                                   link={"/jobs"} 
                                   text={'Browse Jobs'} 
                                   bgColor={'bg-black'} 
                                   bgHoverColor={'bg-gray-700'}
                              />
                         </Card>
                         <Card bgColor="bg-indigo-100">
                              <h2 className="text-2xl font-bold">For Employers</h2>
                              <p className="mt-2 mb-4">
                                   List your job to find the perfect developer for the role
                              </p>
                              <CardButton 
                                   link={'/jobs/add'} 
                                   text={'Add Job'} 
                                   bgColor={'bg-indigo-500'} 
                                   bgHoverColor={'bg-indigo-600'}
                              />
                         </Card>
                    </div>
               </div>
          </section>
     )
}

export default HomeCards