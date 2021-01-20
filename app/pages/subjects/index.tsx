import { useSubjectsBySemester, useSubjectTypes } from '../../actions/subject'
import { Button } from '../../components/Forms/Button/Button'

import { useRouter } from 'next/router'
import { ModalType } from '../../types/types'
import { useStore } from '../../utils/storeProvider'
import { ListSubject } from '../../components/page/Subject/ListSubject'
import { LeadingColor } from '../../types/color'

export const SubjectListView = () => {
  useRouter()
  const setModalType = useStore((state) => state.view.setModalType)
  const { subjectArray, isLoading } = useSubjectsBySemester()
  const subjectTypesRequest = useSubjectTypes()

  const renderSubjects = () =>
    !subjectTypesRequest.isLoading &&
    !isLoading &&
    subjectArray?.map(({ name, subjectKey, typeDefinitionKey }) => (
      <ListSubject
        key={subjectKey}
        type={
          subjectTypesRequest?.subjectTypes &&
          subjectTypesRequest?.subjectTypes[typeDefinitionKey]
        }
        name={name}
        subjectKey={subjectKey}
      />
    ))

  return (
    <section>
      <style jsx>
        {`
          ul {
            padding-right: 30px;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
          }

          header {
            height: 75px;
            padding-right: 30px;
            background: ${LeadingColor};
            display: flex;
            justify-content: flex-end;
            align-items: center;
          }
        `}
      </style>
      <header>
        <Button
          contrast={false}
          onClick={() => setModalType(ModalType.AddSubject)}
        >
          + Dodaj przedmiot
        </Button>
      </header>
      <ul>{renderSubjects()}</ul>
    </section>
  )
}

export default SubjectListView
