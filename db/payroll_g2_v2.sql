-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 15, 2021 at 11:08 AM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `payroll_g2_v2`
--

-- --------------------------------------------------------

--
-- Table structure for table `deleted_payroll`
--

CREATE TABLE `deleted_payroll` (
  `id` int(255) NOT NULL,
  `employee_id` int(100) NOT NULL,
  `no_of_hours` int(50) NOT NULL,
  `net_income` int(150) NOT NULL,
  `overtime_hours` int(50) NOT NULL,
  `overtime_fees` int(100) NOT NULL,
  `sss` int(100) NOT NULL,
  `pagibig` int(100) NOT NULL,
  `philhealth` int(100) NOT NULL,
  `tax` int(100) NOT NULL,
  `total_deduction` int(100) NOT NULL,
  `netpay` int(100) NOT NULL,
  `date_created` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `deleted_payroll`
--

INSERT INTO `deleted_payroll` (`id`, `employee_id`, `no_of_hours`, `net_income`, `overtime_hours`, `overtime_fees`, `sss`, `pagibig`, `philhealth`, `tax`, `total_deduction`, `netpay`, `date_created`) VALUES
(100, 2147483647, 8, 867, 0, 0, 50, 65, 71, 104, 290, 577, '2021-06-14 18:54:03'),
(101, 2147483647, 15, 1625, 0, 0, 93, 122, 133, 195, 543, 1082, '2021-06-15 16:38:44'),
(102, 2147483647, 9, 975, 0, 0, 56, 73, 80, 117, 326, 649, '2021-06-15 16:40:30'),
(103, 2147483647, 5, 542, 0, 0, 31, 41, 44, 65, 181, 361, '2021-06-15 16:40:35');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `employee_id` varchar(255) NOT NULL,
  `first_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `employee_id`, `first_name`) VALUES
(257, '2021061418470', 'cess'),
(258, '2021061418511', 'rothe'),
(259, '2021061516332', 'agpaoa'),
(260, '2021061516373', 'constantino'),
(261, '2021061516374', 'sir jep');

-- --------------------------------------------------------

--
-- Table structure for table `payroll`
--

CREATE TABLE `payroll` (
  `id` int(11) NOT NULL,
  `employee_id` varchar(225) NOT NULL,
  `no_of_hours` int(11) NOT NULL,
  `net_income` int(11) NOT NULL,
  `overtime_hours` int(11) NOT NULL,
  `overtime_fees` int(11) NOT NULL,
  `sss` int(11) NOT NULL,
  `pagibig` int(11) NOT NULL,
  `philhealth` int(11) NOT NULL,
  `tax` int(11) NOT NULL,
  `total_deduction` int(11) NOT NULL,
  `netpay` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `payroll`
--

INSERT INTO `payroll` (`id`, `employee_id`, `no_of_hours`, `net_income`, `overtime_hours`, `overtime_fees`, `sss`, `pagibig`, `philhealth`, `tax`, `total_deduction`, `netpay`) VALUES
(265, '2021061516374', 40, 4333, 0, 0, 248, 325, 355, 520, 1448, 2885);

-- --------------------------------------------------------

--
-- Table structure for table `payroll_history`
--

CREATE TABLE `payroll_history` (
  `id` int(255) NOT NULL,
  `employee_id` int(100) NOT NULL,
  `no_of_hours` int(50) NOT NULL,
  `net_income` int(150) NOT NULL,
  `overtime_hours` int(50) NOT NULL,
  `overtime_fees` int(100) NOT NULL,
  `sss` int(100) NOT NULL,
  `pagibig` int(100) NOT NULL,
  `philhealth` int(100) NOT NULL,
  `tax` int(100) NOT NULL,
  `total_deduction` int(100) NOT NULL,
  `netpay` int(100) NOT NULL,
  `date_created` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `payroll_history`
--

INSERT INTO `payroll_history` (`id`, `employee_id`, `no_of_hours`, `net_income`, `overtime_hours`, `overtime_fees`, `sss`, `pagibig`, `philhealth`, `tax`, `total_deduction`, `netpay`, `date_created`) VALUES
(99, 2147483647, 8, 867, 0, 0, 50, 65, 71, 104, 290, 577, '2021-06-14 18:50:14'),
(100, 2147483647, 9, 975, 0, 0, 56, 73, 80, 117, 326, 649, '2021-06-14 18:52:00'),
(101, 2147483647, 15, 1625, 0, 0, 93, 122, 133, 195, 543, 1082, '2021-06-15 16:35:29');

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE `question` (
  `id` int(11) NOT NULL,
  `question` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`id`, `question`) VALUES
(1, 'What is your favorite color?'),
(2, 'Who is your first teacher?'),
(3, 'What is your nickname?');

-- --------------------------------------------------------

--
-- Table structure for table `security_question`
--

CREATE TABLE `security_question` (
  `id` int(11) NOT NULL,
  `employee_id` varchar(50) NOT NULL,
  `question` varchar(50) NOT NULL,
  `answer` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `security_question`
--

INSERT INTO `security_question` (`id`, `employee_id`, `question`, `answer`) VALUES
(1, '61121_0001', '1', 'black'),
(2, '61221_0002', '2', 'jep');

-- --------------------------------------------------------

--
-- Table structure for table `user_account`
--

CREATE TABLE `user_account` (
  `id` int(11) NOT NULL,
  `employee_id` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email_address` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user_account`
--

INSERT INTO `user_account` (`id`, `employee_id`, `username`, `password`, `email_address`) VALUES
(1, '61121_0001', 'resty', 'kahitano', 'admin0001@gmail.com'),
(2, '61221_0002', 'test', 'zzzz', 'potolinresty110394@gmail.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `deleted_payroll`
--
ALTER TABLE `deleted_payroll`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payroll`
--
ALTER TABLE `payroll`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payroll_history`
--
ALTER TABLE `payroll_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `security_question`
--
ALTER TABLE `security_question`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_account`
--
ALTER TABLE `user_account`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `deleted_payroll`
--
ALTER TABLE `deleted_payroll`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=104;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=262;

--
-- AUTO_INCREMENT for table `payroll`
--
ALTER TABLE `payroll`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=266;

--
-- AUTO_INCREMENT for table `payroll_history`
--
ALTER TABLE `payroll_history`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT for table `question`
--
ALTER TABLE `question`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `security_question`
--
ALTER TABLE `security_question`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user_account`
--
ALTER TABLE `user_account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
