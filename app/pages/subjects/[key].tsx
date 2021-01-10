import { useSubject } from '../../actions/subject'
import { useRouter } from 'next/router'

const SubjectPage = () => {
  const { query } = useRouter()
  const { subject, isLoading, isError } = useSubject(query.key)

  return (
    <>
      {isLoading && <h1>Loading</h1>}
      <title>Subject</title>
      <h1>Subject</h1>
    </>
  )
}

export default SubjectPage
