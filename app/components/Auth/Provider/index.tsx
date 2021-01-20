import React, { createContext, FC, useEffect, useState } from 'react'
import { useRouter } from 'next/router'
import { ModalWrapper } from '../../../forms/ModalWrapper'
import LoadingPage from '../../page/LoadingPage'
import { useStore } from '../../../utils/storeProvider'
import { setSemesters } from '../../../store/modules/user/userSelectors'
import { useUserSemesters } from '../../../actions/user/useUserSemesters'
import { ModalType } from '../../../types/types'

interface GlobalDataContext {
  modalType: ModalType
  setModalType: (modalType: ModalType) => void
}
export const GlobalDataContext = createContext<GlobalDataContext>({
  modalType: ModalType.AddSubject,
  setModalType: () => {},
})

export const GlobalDataProvider: FC = (props) => {
  const [modalType, setModalType] = useState(ModalType.AddSubject)

  return (
    <GlobalDataContext.Provider value={{ modalType, setModalType }}>
      {props.children}
    </GlobalDataContext.Provider>
  )
}

export const AuthProvider: FC = (props) => {
  const { isError, isLoading, mutate, semesters } = useUserSemesters()

  const { pathname, push } = useRouter()
  const [pathRequested, setPathRequested] = useState(pathname)

  const setSemestersLocal = useStore(setSemesters)
  const semesterKeys = semesters && Object.keys(semesters)

  useEffect(() => {
    if (semesters && semesterKeys) {
      setSemestersLocal(semesters)
      if (semesterKeys.length === 0) {
        push('/login')
      } else if (semesterKeys.length > 0 && pathRequested) {
        push(pathRequested)
      }
    }
  }, [semesters])

  return !semesters ||
    (semesterKeys?.length === 0 && pathname === 'login') ||
    pathname === 'register' ? (
    <LoadingPage />
  ) : (
    <GlobalDataProvider>
      {/*<Navigation />*/}
      {props.children}
      <ModalWrapper />
    </GlobalDataProvider>
  )
}

// source https://blog.logrocket.com/using-authentication-in-next-js/
