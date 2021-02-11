import { VStack } from '@chakra-ui/layout'
import Calendar from '../../public/icons/sidebar/calendar.svg'
import Dashboard from '../../public/icons/sidebar/Dashboard.svg'
import Subjects from '../../public/icons/sidebar/Subjects.svg'
import Projects from '../../public/icons/sidebar/Subjects.svg'
import { Flex, LinkBox, LinkOverlay, Box } from '@chakra-ui/react'
import NextLink from 'next/link'
import { Link } from '@chakra-ui/react'

interface Data {
  icon: JSX.Element
  href: string
}

export const Navigation = () => {
  const navigationData: Record<string, Data> = {
    Dashboard: {
      icon: <Dashboard />,
      href: '/app',
    },
    Kalendarz: {
      icon: <Calendar />,
      href: '/calendar',
    },
    Przedmioty: {
      icon: <Subjects />,
      href: '/subjects',
    },
    Projekty: {
      icon: <Projects />,
      href: '/projects',
    },
  }

  const renderNavigation = () =>
    Object.keys(navigationData).map((key) => (
      <Box
        key={key}
        marginLeft={5}
        marginRight={5}
        marginBottom={5}
        as={Flex}
        flexDir="row"
        alignItems="center"
        color={'white'}
      >
        {navigationData[key].icon}
        <Link as={NextLink} href={navigationData[key].href}>
          {key}
        </Link>
      </Box>
    ))

  return (
    <Flex pt={150} flexDir="column" h="100vh" backgroundColor="#2B2E61">
      {renderNavigation()}
    </Flex>
  )
}
