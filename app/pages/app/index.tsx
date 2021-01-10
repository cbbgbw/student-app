import React, { FC } from 'react'

import { EntitiesModal } from '../../types/types'
import { Add } from '../../components/Add/Add'
import { useStore } from '../../utils/storeProvider'
import { initializeStore } from '../../utils/storeUtils'

import styles from './index.module.scss'

const App: FC = () => {
  const { setModalType } = useStore()

  const generateAddButtons = () =>
    Object.keys(EntitiesModal).map((value) => (
      <Add
        key={value}
        name={value.toLowerCase()}
        onClick={() => setModalType(EntitiesModal[value])}
      />
    ))

  return (
    <>
      {/* <aside className={styles.sidebar}> */}
      {/*  <Link href={"/"}> */}
      {/*    <a>Dashboard</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/calendar"}> */}
      {/*    <a>Calendar</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/subjects"}> */}
      {/*    <a>Subjects</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/projects"}> */}
      {/*    <a>Projects</a> */}
      {/*  </Link> */}
      {/* </aside> */}
      <section className={styles.app}>
        <section className={styles.addSection}>
          {generateAddButtons()}
        </section>
      </section>
    </>
  )
}

export function getServerSideProps() {
  const zustandStore = initializeStore()

  return {
    props: {
      initialZustandState: JSON.stringify(zustandStore.getState()),
    },
  }
}

export default App
