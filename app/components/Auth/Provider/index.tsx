import React, { FC, useEffect, useState } from 'react'
import useSWR from 'swr'
import { useRouter } from 'next/router'
import { AuthContext } from '../Context/Context'
import { baseURL } from '../../../actions/common/common'
import { Navigation } from '../../Navigation/Navigation'
import { ModalWrapper } from '../../../forms/ModalWrapper'
import LoadingPage from '../../page/LoadingPage'
import { useStore } from '../../../utils/storeProvider'
import { setSemesters } from '../../../store/modules/user/userSelectors'
import { useUserSemesters } from '../../../actions/user/useUserSemesters'

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
    <>
      <Navigation />
      {props.children}
      <ModalWrapper />
    </>
  )
}

// source https://blog.logrocket.com/using-authentication-in-next-js/
